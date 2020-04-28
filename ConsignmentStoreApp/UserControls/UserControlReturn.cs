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
    public partial class UserControlReturn : UserControl
    {
        private static UserControlReturn instance;
        private ConsignmentStoreEntities context = ConsignmentStoreBusinessLogic.context;
        private ConsignmentResult consignmentResult;
        private StringBuilder stringBuilder = new StringBuilder();

        public static UserControlReturn Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserControlReturn();

                return instance;
            }
        }

        public UserControlReturn()
        {
            InitializeComponent();

            Load += UserControlReturn_Load;
        }

        private void UserControlReturn_Load(object sender, EventArgs e)
        {
            //binding datagridview
            FormHelper.InitializeDataGridViewSettings(dataGridViewConsignmentResults);

            //binding to dataGridView
            dataGridViewConsignmentResults.DataSource = context.ConsignmentResults.Local
                    //not yet returned results
                    .Where(result =>!result.ReturnedDate.HasValue && !result.ReturnedBy.HasValue).ToList();
            dataGridViewConsignmentResults.Columns["ConsignmentSummary"].Visible = false;
            dataGridViewConsignmentResults.Columns["Consignor"].Visible = false;
            dataGridViewConsignmentResults.Columns["Employee"].Visible = false;
            dataGridViewConsignmentResults.Columns["NumberOfLostItems"].Visible = false;
            dataGridViewConsignmentResults.Columns["TotalValueOfLostItems"].Visible = false;
            dataGridViewConsignmentResults.Columns["NumberOfSoldItems"].Visible = false;
            dataGridViewConsignmentResults.Columns["TotalValueOfSoldItems"].Visible = false;

            foreach (int colNum in new int[] { 3, 5, 7, 8 })// format money
            {
                dataGridViewConsignmentResults.Columns[colNum].DefaultCellStyle.Format = "N2";
                dataGridViewConsignmentResults.Columns[colNum].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            //view result detail
            dataGridViewConsignmentResults.CellDoubleClick += DisplayDetailOfConsignmentResult;

            //return a result
            buttonReturn.Click += ReturnResult;

            //search textbox
            textBoxSearch.TextChanged += SearchConsignmentResultByConsignorId;
        }

        private void SearchConsignmentResultByConsignorId(object sender, EventArgs e)
        {
            string searchString = textBoxSearch.Text.ToString();
            if (searchString != "")
            {
                dataGridViewConsignmentResults.DataSource = context.ConsignmentResults.Local
                    .Where(result => 
                        //not yet returned results
                        !result.ReturnedDate.HasValue && !result.ReturnedBy.HasValue &&
                        //match search string by ConsignorId or ConsignmentPeriod
                        (result.ConsignorId.ToString().Contains(searchString) || 
                        result.ConsignmentPeriod.ToString().Contains(searchString)
                        )).ToList();
            }
            else
            {
                dataGridViewConsignmentResults.DataSource = context.ConsignmentResults.Local
                    .Where(result =>  //not yet returned results
                        !result.ReturnedDate.HasValue && !result.ReturnedBy.HasValue).ToList();
            }
            dataGridViewConsignmentResults.Refresh();
        }

        private void ReturnResult(object sender, EventArgs e)
        {
            if (consignmentResult == null)
                return;//no result is selected

            //update consignment result table
            consignmentResult.ReturnedDate = DateTime.Now;
            consignmentResult.ReturnedBy = ConsignmentStoreBusinessLogic.loggedInEmployee.EmployeeId;

            //update expenses table
            context.Expenses.Add(new Expens
            {//set ConsignmentResult expense date =  ReturnedDate
                Date = (DateTime)consignmentResult.ReturnedDate,
                Amount = consignmentResult.TotalValueReceivedByConsignor,
                Category = "ConsignmentResult"
            });

            context.SaveChanges();//save to database

            consignmentResult = null;

            //refresh view
            dataGridViewConsignmentResults.DataSource = context.ConsignmentResults.Where(result => !result.ReturnedDate.HasValue &&
                                    !result.ReturnedBy.HasValue).ToList();
            textBoxResultDetail.Text = GetConsignmentResultDetails(consignmentResult);
        }

        private void DisplayDetailOfConsignmentResult(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)//not header row
            {
                int consignorId = int.Parse(dataGridViewConsignmentResults.Rows[e.RowIndex].Cells[0].Value.ToString());
                int consignmentPeriod = int.Parse(dataGridViewConsignmentResults.Rows[e.RowIndex].Cells[1].Value.ToString());

                //get the consignment result
                consignmentResult = context.ConsignmentResults.Local.Single(result => 
                        result.ConsignmentPeriod == consignmentPeriod &&
                        result.ConsignorId == consignorId);

                //display it
                textBoxResultDetail.Text = GetConsignmentResultDetails(consignmentResult);
            }
        }

        private string GetConsignmentResultDetails(ConsignmentResult result)
        {
            if (result == null)
                return "";

            stringBuilder.Clear();
            stringBuilder.AppendLine(string.Format("{0,-20} {1}", "Consignor Id",
                result.Consignor.ConsignorId));
            stringBuilder.AppendLine(string.Format("{0,-20} {1}", "Consignor Name",
                result.Consignor.ConsignorName.Trim()));
            stringBuilder.AppendLine(string.Format("{0,-20} {1}", "Consignor DOB",
                ((DateTime)result.Consignor.ConsignorDOB).ToString("dd MMMM yyyy")));
            stringBuilder.AppendLine(string.Format("{0,-20} {1}", "Consignor Phone",
                result.Consignor.ConsignorPhone.Trim()));
            stringBuilder.AppendLine(string.Format("{0,-20} {1}", "Consignor Email",
                result.Consignor.ConsignorEmail.Trim()));
            stringBuilder.AppendLine(string.Format("{0,-20} {1}", "Consignor Period",
                ConsignmentStoreBusinessLogic.GetConsignmentPeriodFromInt(result.ConsignmentPeriod)));
            stringBuilder.AppendLine(string.Format("{0,-20} {1:n0}", "Returned Items",
                result.NumberOfReturnedItems));
            stringBuilder.AppendLine(string.Format("{0,-20} {1:c}", "Value Items",
                result.TotalValueOfReturnedItems));
            stringBuilder.AppendLine(string.Format("{0,-20} {1:c}", "Consignment Result",
                result.TotalValueReceivedByConsignor));

            return stringBuilder.ToString();
        }
    }
}
