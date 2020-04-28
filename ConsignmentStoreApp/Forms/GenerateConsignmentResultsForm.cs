using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsignmentStoreApp.EF_Classes;
using System.Data.Entity;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConsignmentStoreApp.Controller;
using ConsignmentStoreApp.Utilities;
using ConsignmentStoreApp.Forms;

namespace ConsignmentStoreApp.Forms
{
    public partial class GenerateConsignmentResultsForm : Form
    {
        private ConsignmentStoreEntities context = ConsignmentStoreBusinessLogic.context;
        private int consignmentPeriod;

        public GenerateConsignmentResultsForm(int period)
        {
            InitializeComponent();

            //set consignment period
            consignmentPeriod = period;

            Load += GenerateConsignmentResultsForm_Load;

            //if form closed, discard changes in Items
            FormClosed += DiscardChangesInItems;
        }

        private void DiscardChangesInItems(object sender, FormClosedEventArgs e)
        {
            //load unsold - items data from the period 
            context.Items.Where(item =>
                item.ItemStatus == ConsignmentStoreBusinessLogic.ITEM_STATUS_UNSOLD &&
                item.ConsignedDate.Month == consignmentPeriod % 100 &&
                item.ConsignedDate.Year == consignmentPeriod / 100).Load();
        }

        private void GenerateConsignmentResultsForm_Load(object sender, EventArgs e)
        {
            //set title
            labelTitleDisplay.Text = "Checking Lost Items for Consignment Period " +
                ConsignmentStoreBusinessLogic.GetConsignmentPeriodFromInt(consignmentPeriod);

            //load unsold - items data from the period 
            context.Items.Where(item => 
                item.ItemStatus == ConsignmentStoreBusinessLogic.ITEM_STATUS_UNSOLD &&
                item.ConsignedDate.Month == consignmentPeriod % 100 &&
                item.ConsignedDate.Year == consignmentPeriod / 100).Load();

            //setup datagridview
            FormHelper.InitializeDataGridViewSettings(dataGridViewItems);

            //binding to dataGridView
            dataGridViewItems.DataSource = context.Items.Local.ToBindingList();
            dataGridViewItems.Columns["SoldItem"].Visible = false;
            dataGridViewItems.Columns["Employee"].Visible = false;
            dataGridViewItems.Columns["Consignor"].Visible = false;

            //toggle status of item by double-click
            dataGridViewItems.CellDoubleClick += ToggleItemStatusLostOrUnsold;

            //filter by consignorId
            textBoxSearch.TextChanged += SearchByConsignorId;

            //button finish is clicked
            buttonFinishGenerateConsignmentResults.Click += GenerateConsignmentResults;
        }

        private void GenerateConsignmentResults(object sender, EventArgs e)
        {
            //change all local items that have status "unsold" to "returned" and save to database
            foreach (var item in context.Items.Local.Where(i =>
                 i.ItemStatus.Trim() == ConsignmentStoreBusinessLogic.ITEM_STATUS_UNSOLD))
                item.ItemStatus = ConsignmentStoreBusinessLogic.ITEM_STATUS_RETURNED;

            context.SaveChanges();//save to database

            //generate consignment results
            if (ConsignmentStoreBusinessLogic.GenerateConsignmentResultsForPeriod(consignmentPeriod))
            {
                FormHelper.ShowInfoMessageBox("Consignment Results for Period " +
                    ConsignmentStoreBusinessLogic.GetConsignmentPeriodFromInt(consignmentPeriod) + " are creared!");
                
                //success then close the form
                Close();
            }
            else
            {
                FormHelper.ShowErrorMessageBox("Consignment Results for Period " +
                    ConsignmentStoreBusinessLogic.GetConsignmentPeriodFromInt(consignmentPeriod) + " cannot creared. Please try again!");
            }
        }

        private void SearchByConsignorId(object sender, EventArgs e)
        {
            string searchString = textBoxSearch.Text.ToString();
            if (searchString != "")
            {
                dataGridViewItems.DataSource = context.Items.Local
                    .Where(i => i.ConsignorId.ToString().Trim() ==
                        searchString).ToList();
            }
            else
            {
                dataGridViewItems.DataSource = context.Items.Local.ToBindingList();
            }
            dataGridViewItems.Refresh();
        }

        private void ToggleItemStatusLostOrUnsold(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)//not header row
            {
                //get id
                int itemId = int.Parse(dataGridViewItems.Rows[e.RowIndex].Cells[0].Value.ToString());

                //get item
                Item item = context.Items.Local.Single(i => i.ItemId == itemId);

                //toggle status unsold - lost
                item.ItemStatus = item.ItemStatus == ConsignmentStoreBusinessLogic.ITEM_STATUS_UNSOLD ?
                    ConsignmentStoreBusinessLogic.ITEM_STATUS_LOST : ConsignmentStoreBusinessLogic.ITEM_STATUS_UNSOLD;

                //update datagridview
                dataGridViewItems.Refresh();
            }
        }
    }
}
