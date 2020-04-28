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
    public partial class UserControlManageConsignors : UserControl
    {
        private static UserControlManageConsignors instance;
        private ConsignmentStoreEntities context = ConsignmentStoreBusinessLogic.context;

        public static UserControlManageConsignors Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserControlManageConsignors();

                return instance;
            }
        }
        public UserControlManageConsignors()
        {
            InitializeComponent();

            Load += UserControlManageConsignors_Load;
        }

        private void UserControlManageConsignors_Load(object sender, EventArgs e)
        {
            FormHelper.InitializeDataGridViewSettings(dataGridViewAll);
            context.Consignors.Load();//load from database

            dataGridViewAll.DataSource = context.Consignors.Local.ToBindingList();//binding to dataGridView
            dataGridViewAll.Columns["ConsignmentResults"].Visible = false;
            dataGridViewAll.Columns["Items"].Visible = false;

            //add button
            buttonAdd.Click += AddConsignor;
            //edit when doubleclick
            dataGridViewAll.CellDoubleClick += EditConsignor;
            //search textbox
            textBoxSearch.TextChanged += UpdateSearchResults;
        }

        private void UpdateSearchResults(object sender, EventArgs e)
        {
            string searchString = textBoxSearch.Text.ToString();
            if (searchString != "")
            {
                dataGridViewAll.DataSource = context.Consignors.Local
                    .Where(c => c.ConsignorEmail.Contains(searchString) ||
                            c.ConsignorPhone.Contains(searchString) ||
                            c.ConsignorName.Contains(searchString) ||
                            c.ConsignorDOB.ToString().Contains(searchString)).ToList();
            }
            else
            {
                dataGridViewAll.DataSource = context.Consignors.Local.ToBindingList();
            }
            dataGridViewAll.Refresh(); 
        }

        private void AddConsignor(object sender, EventArgs e)
        {
            Consignor consignor = null;

            AddEditConsignorForm addEditConsignorForm = new AddEditConsignorForm(consignor);
            addEditConsignorForm.ShowDialog();
            addEditConsignorForm.Dispose();

            dataGridViewAll.Refresh();

        }

        //edit when double click
        private void EditConsignor(Object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)//not header row
            {
                int consignorId = int.Parse(dataGridViewAll.Rows[e.RowIndex].Cells[0].Value.ToString());
                Consignor consignor = context.Consignors.Find(consignorId);

                AddEditConsignorForm addEditConsignorForm = new AddEditConsignorForm(consignor);
                addEditConsignorForm.ShowDialog();

                dataGridViewAll.Refresh();

            }
        }
    }
}
