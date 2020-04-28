using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
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

namespace ConsignmentStoreApp.UserControls
{
    public partial class UserControlConsign : UserControl
    {
        private static UserControlConsign instance;
        private ConsignmentStoreEntities context = ConsignmentStoreBusinessLogic.context;
        AutoCompleteStringCollection autoCompleteConsignors;
        List<Item> items = new List<Item>();//contain temporal consigned items

        public static UserControlConsign Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserControlConsign();

                return instance;
            }
        }

        public UserControlConsign()
        {
            InitializeComponent();

            Load += UserControlConsign_Load;
        }

        private void UserControlConsign_Load(object sender, EventArgs e)
        {
            //auto complete consignor email
            autoCompleteConsignors = new AutoCompleteStringCollection();
            //binding autocomplete with consignor textbox
            textBoxConsignor.AutoCompleteCustomSource = autoCompleteConsignors;

            //binding datagridview with list of items
            dataGridViewItems.DataSource = items.ToList();

            //set up datagridview
            FormHelper.InitializeDataGridViewSettings(dataGridViewItems);
            dataGridViewItems.Columns["ItemId"].Visible = false;
            dataGridViewItems.Columns["SoldItem"].Visible = false;
            dataGridViewItems.Columns["Employee"].Visible = false;
            dataGridViewItems.Columns["Consignor"].Visible = false;

            //Add button - add items to temporal list and display them
            buttonAddItems.Click += AddItems;

            //Finish button - add items to database and reset UI
            buttonFinish.Click += FinishConsignment;
        }

        public void RefreshView()
        {
            if (context.Consignors.Local.Count == autoCompleteConsignors.Count)
                return;//no consignor is added

            autoCompleteConsignors.AddRange(context.Consignors.Local.Select(consignor =>consignor.ConsignorEmail).ToArray());
        }

        private void FinishConsignment(object sender, EventArgs e)
        {
            //no items to save
            if (items.Count == 0)
                return;

            //save data 
            context.Items.AddRange(items);
            try
            {
                context.SaveChanges();
                FormHelper.ShowInfoMessageBox("Successfully add items!");
            }
            catch
            {
                FormHelper.ShowErrorMessageBox("Cannot add items. Please try again!");
            }

            //clear items
            items.Clear();
            dataGridViewItems.DataSource = items;

            //reset No Items and Total Value textboxes
            textBoxNumberOfItems.Text = "0";
            textBoxTotalValue.Text = "0.00";

            //reset price and repeat
            numericUpDownRepeat.Value = 1;
            numericUpDownPrice.Value = 10;

            //clear and focus textbox consignor
            textBoxConsignor.Clear();
            textBoxConsignor.Focus();
        }

        private void AddItems(object sender, EventArgs e)
        {
            //validate date - date cannot in the past
            if(DateTime.Now > dateTimePickerConsignedDate.Value.AddMinutes(60)) 
            {
                FormHelper.ShowErrorMessageBox("Date cannot in the past. \nPlease try again!");
                return;
            }

            //validate consignor must be in autoCompleteConsignors
            if (autoCompleteConsignors.Contains(textBoxConsignor.Text.ToString()))
            {
                Consignor consignor = context.Consignors.Single(c => c.ConsignorEmail == textBoxConsignor.Text.ToString());
                for(int i=0; i<numericUpDownRepeat.Value; i++)
                {
                    items.Add(new Item
                    {
                        ConsignorId = consignor.ConsignorId,
                        ConsignedDate = dateTimePickerConsignedDate.Value,
                        Price = numericUpDownPrice.Value,
                        ItemStatus = ConsignmentStoreBusinessLogic.ITEM_STATUS_UNSOLD,
                        ConsignedBy = ConsignmentStoreBusinessLogic.loggedInEmployee.EmployeeId
                    });
                }

                dataGridViewItems.DataSource = items.ToList();//update datagridview

                textBoxNumberOfItems.Text = items.Count.ToString();
                textBoxTotalValue.Text = "$" + items.Sum(item => item.Price).ToString("n2");


            }
            else
            {
                FormHelper.ShowErrorMessageBox("Consignor email does not exist. \nPlease try again or add new consignor!");
            }
        }
    }
}
