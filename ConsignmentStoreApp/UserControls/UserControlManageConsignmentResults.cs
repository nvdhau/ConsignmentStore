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
    public partial class UserControlManageConsignmentResults : UserControl
    {
        private static UserControlManageConsignmentResults instance;
        private ConsignmentStoreEntities context = ConsignmentStoreBusinessLogic.context;

        public static UserControlManageConsignmentResults Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserControlManageConsignmentResults();

                return instance;
            }
        }

        public UserControlManageConsignmentResults()
        {
            InitializeComponent();

            Load += UserControlManageConsignmentResults_Load;
        }

        private void UserControlManageConsignmentResults_Load(object sender, EventArgs e)
        {
            //add consignment periods to combox box (format: month/year) 
            foreach (var period in context.ConsignmentSummaries.Local.ToList())
                comboBoxConsignmentPeriods.Items.Add(
                    ConsignmentStoreBusinessLogic.GetConsignmentPeriodFromInt(period.ConsignmentPeriod));

            //binding datagridview
            FormHelper.InitializeDataGridViewSettings(dataGridViewConsignmentResults);
            FormHelper.InitializeDataGridViewSettings(dataGridViewConsignmentSummaries);

            dataGridViewConsignmentResults.DataSource = context.ConsignmentResults.Local.ToBindingList();//binding to dataGridView
            dataGridViewConsignmentResults.Columns["ConsignmentSummary"].Visible = false;
            dataGridViewConsignmentResults.Columns["Consignor"].Visible = false;
            dataGridViewConsignmentResults.Columns["Employee"].Visible = false;
            foreach (int colNum in new int[] { 3, 5, 7, 8 })// format money
            {
                dataGridViewConsignmentResults.Columns[colNum].DefaultCellStyle.Format = "N2";
                dataGridViewConsignmentResults.Columns[colNum].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            dataGridViewConsignmentSummaries.DataSource = context.ConsignmentSummaries.Local.ToBindingList();//binding to dataGridView
            dataGridViewConsignmentSummaries.Columns["ConsignmentResults"].Visible = false;

            foreach (int colNum in new int[] {1,2,4,7,9})// format number
                dataGridViewConsignmentSummaries.Columns[colNum].DefaultCellStyle.Format = "N0";

            foreach (int colNum in new int[] { 3, 5, 6, 8, 10, 11 })// format money
            {
                dataGridViewConsignmentSummaries.Columns[colNum].DefaultCellStyle.Format = "N2";
                dataGridViewConsignmentSummaries.Columns[colNum].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }


            //combobox 
            comboBoxConsignmentPeriods.SelectedIndexChanged += UpdateConsignmentPeriod;

            //button generate consignment results
            buttonGenerateConsignmentResults.Click += GenerateConsignmentResults;
        }

        private void GenerateConsignmentResults(object sender, EventArgs e)
        {
            //consignment period must 
            //1. must be greater than the largest consignmentPeriod (e.g. current is 201901)
            //2. must less than current month (e.g. 201904)
            //valid consignmentPeriods are  201902, 201903

            //convert selected item in combobox to consignmentPeriod
            int consignmentPeriod = ConsignmentStoreBusinessLogic.GetConsignmentPeriodFromString(
                (int)numericUpDownMonth.Value + "/" + (int)numericUpDownYear.Value);

            int upLimitConsignmentPeriod = ConsignmentStoreBusinessLogic.GetConsignmentPeriodFromString(
                DateTime.Now.Month + "/" + DateTime.Now.Year);

            int downLimitConsignmentPeriod = context.ConsignmentSummaries.Max(summary => summary.ConsignmentPeriod);

            if(!ConsignmentStoreBusinessLogic.ValidateConsignmentPeriod(consignmentPeriod))
            {
                FormHelper.ShowErrorMessageBox("Period must greater than " +
                    ConsignmentStoreBusinessLogic.GetConsignmentPeriodFromInt(downLimitConsignmentPeriod) + " and less than " +
                    ConsignmentStoreBusinessLogic.GetConsignmentPeriodFromInt(upLimitConsignmentPeriod));
                return;
            }

            //Checking lost items
            GenerateConsignmentResultsForm generateConsignmentResultsForm = new GenerateConsignmentResultsForm(consignmentPeriod);
            generateConsignmentResultsForm.ShowDialog();
            generateConsignmentResultsForm.Dispose();

            //Load combobox again
            comboBoxConsignmentPeriods.Items.Clear();
            //add consignment periods to combox box (format: month/year) 
            foreach (var period in context.ConsignmentSummaries.Local.ToList())
                comboBoxConsignmentPeriods.Items.Add(
                    ConsignmentStoreBusinessLogic.GetConsignmentPeriodFromInt(period.ConsignmentPeriod));

        }

        private void UpdateConsignmentPeriod(object sender, EventArgs e)
        {
            //convert selected item in combobox to consignmentPeriod
            int consignmentPeriod = ConsignmentStoreBusinessLogic.GetConsignmentPeriodFromString(
                comboBoxConsignmentPeriods.SelectedItem.ToString());

            //update consignment results and summaries data gridviews
            dataGridViewConsignmentResults.DataSource = context.ConsignmentResults.Local.Where(
                result=>result.ConsignmentPeriod == consignmentPeriod).ToList();

            dataGridViewConsignmentSummaries.DataSource = context.ConsignmentSummaries.Local.Where(
                summary => summary.ConsignmentPeriod == consignmentPeriod).ToList();

        }
    }
}
