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
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ConsignmentStoreApp.UserControls
{
    public partial class UserControlReportsAndBackup : UserControl
    {
        private static UserControlReportsAndBackup instance;
        private ConsignmentStoreEntities context = ConsignmentStoreBusinessLogic.context;

        public static UserControlReportsAndBackup Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserControlReportsAndBackup();

                return instance;
            }
        }

        public UserControlReportsAndBackup()
        {
            InitializeComponent();

            Load += UserControlReports_Load;
        }

        private void UserControlReports_Load(object sender, EventArgs e)
        {

            //run update overview
            ConsignmentStoreBusinessLogic.UpdateOverview();
            DisplayOverview();

            //Backup database
            buttonBackupData.Click += ButtonBackupData_Click;

            //Restore data from xml files
            buttonRestore.Click += ButtonRestore_Click;
        }

        private void ButtonRestore_Click(object sender, EventArgs e)
        {
            string filename = "Consignors.xml";
            var path = Path.GetFullPath(Application.StartupPath + "\\..\\..\\BackupData\\" + filename);
            StreamReader file = new StreamReader(path);// Open file for reading

            // Create the serializer
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Consignor>));
            List<Consignor> consignors;
            try
            {
                // Deserialize to the list of house objects
                consignors = xmlSerializer.Deserialize(file) as List<Consignor>;
                file.Close();// Close file

                foreach(var consignor in consignors)
                {
                    Console.WriteLine("Name "+consignor.ConsignorName);
                }
            }
            catch (Exception ex)
            {
                FormHelper.ShowErrorMessageBox("Cannot restore!");
            }
        }


        //Backup data to xml files
        private void ButtonBackupData_Click(object sender, EventArgs e)
        {
            try
            {
                //Backup Consignors
                context.Consignors.Load();

                string filename = "Consignors.xml";
                var path = Path.GetFullPath(Application.StartupPath + "\\..\\..\\BackupData\\" + filename);

                XElement xElement = new XElement("Consignors",
                    context.Consignors.Local.Select(model => new {
                        model.ConsignorId,
                        model.ConsignorName,
                        model.ConsignorDOB,
                        model.ConsignorPhone,
                        model.ConsignorEmail
                    }).ToList().Select(x =>
                        new XElement("Consignor",
                        new XAttribute("ConsignorId", x.ConsignorId),
                        new XAttribute("ConsignorName", x.ConsignorName),
                        new XAttribute("ConsignorDOB", x.ConsignorDOB),
                        new XAttribute("ConsignorPhone", x.ConsignorPhone),
                        new XAttribute("ConsignorEmail", x.ConsignorEmail)
                        )));

                xElement.Save(path);//save to file

                //Backup Employees
                context.Employees.Load();

                filename = "Employees.xml";
                path = Path.GetFullPath(Application.StartupPath + "\\..\\..\\BackupData\\" + filename);

                xElement = new XElement("Employees",
                    context.Employees.Local.Select(model => new {
                        model.EmployeeId,
                        model.EmployeeName,
                        model.EmployeeEmail,
                        model.EmployeePhone,
                        model.EmployeePassword,
                        model.EmployeeType
                    }).ToList().Select(x =>
                        new XElement("Employee",
                        new XAttribute("EmployeeId", x.EmployeeId),
                        new XAttribute("EmployeeName", x.EmployeeName),
                        new XAttribute("EmployeeEmail", x.EmployeeEmail),
                        new XAttribute("EmployeePhone", x.EmployeePhone),
                        new XAttribute("EmployeePassword", x.EmployeePassword),
                        new XAttribute("EmployeeType", x.EmployeeType)
                        )));

                xElement.Save(path);//save to file

                //Backup Items
                context.Items.Load();

                filename = "Items.xml";
                path = Path.GetFullPath(Application.StartupPath + "\\..\\..\\BackupData\\" + filename);

                xElement = new XElement("Items",
                    context.Items.Local.Select(model => new {
                        model.ItemId,
                        model.ConsignorId,
                        model.ConsignedDate,
                        model.Price,
                        model.ItemStatus,
                        model.ConsignedBy
                    }).ToList().Select(x =>
                        new XElement("Item",
                        new XAttribute("ItemId", x.ItemId),
                        new XAttribute("ConsignorId", x.ConsignorId),
                        new XAttribute("ConsignedDate", x.ConsignedDate),
                        new XAttribute("Price", x.Price),
                        new XAttribute("ItemStatus", x.ItemStatus),
                        new XAttribute("ConsignedBy", x.ConsignedBy)
                        )));

                xElement.Save(path);//save to file

                //Backup SoldItems
                context.SoldItems.Load(); 

                filename = "SoldItems.xml";
                path = Path.GetFullPath(Application.StartupPath + "\\..\\..\\BackupData\\" + filename);

                xElement = new XElement("SoldItems",
                    context.SoldItems.Local.Select(model => new {
                        model.ItemId,
                        model.SoldBy,
                        model.SoldDate,
                        model.DiscountAmount
                    }).ToList().Select(x =>
                        new XElement("SoldItem",
                        new XAttribute("ItemId", x.ItemId),
                        new XAttribute("SoldBy", x.SoldBy),
                        new XAttribute("SoldDate", x.SoldDate),
                        new XAttribute("DiscountAmount", x.DiscountAmount)
                        )));

                xElement.Save(path);//save to file

                //Backup ConsignmentSummaries
                context.ConsignmentSummaries.Load();

                filename = "ConsignmentSummaries.xml";
                path = Path.GetFullPath(Application.StartupPath + "\\..\\..\\BackupData\\" + filename);

                xElement = new XElement("ConsignmentSummaries",
                    context.ConsignmentSummaries.Local.Select(model => new {
                        model.ConsignmentPeriod,
                        model.NumberOfConsingors,
                        model.NumberOfConsignedItems,
                        model.TotalValueOfConsignedItems,
                        model.NumberOfSoldItems,
                        model.TotalValueOfSoldItems,
                        model.TotalValueOfActualSoldValue,
                        model.NumberOfLostItems,
                        model.TotalValueOfLostItems,
                        model.NumberOfReturnedItems,
                        model.TotalValueOfReturnedItems,
                        model.TotalValueReceivedByConsignors,
                    }).ToList().Select(x =>
                        new XElement("ConsignmentSummary",
                        new XAttribute("ConsignmentPeriod", x.ConsignmentPeriod),
                        new XAttribute("NumberOfConsingors", x.NumberOfConsingors),
                        new XAttribute("NumberOfConsignedItems", x.NumberOfConsignedItems),
                        new XAttribute("TotalValueOfConsignedItems", x.TotalValueOfConsignedItems),
                        new XAttribute("NumberOfSoldItems", x.NumberOfSoldItems),
                        new XAttribute("TotalValueOfSoldItems", x.TotalValueOfSoldItems),
                        new XAttribute("TotalValueOfActualSoldValue", x.TotalValueOfActualSoldValue),
                        new XAttribute("NumberOfLostItems", x.NumberOfLostItems),
                        new XAttribute("TotalValueOfLostItems", x.TotalValueOfLostItems),
                        new XAttribute("NumberOfReturnedItems", x.NumberOfReturnedItems),
                        new XAttribute("TotalValueOfReturnedItems", x.TotalValueOfReturnedItems),
                        new XAttribute("TotalValueReceivedByConsignors", x.TotalValueReceivedByConsignors)
                        )));

                xElement.Save(path);//save to file

                //Backup ConsignmentResults
                context.ConsignmentResults.Load();

                filename = "ConsignmentResults.xml";
                path = Path.GetFullPath(Application.StartupPath + "\\..\\..\\BackupData\\" + filename);

                xElement = new XElement("ConsignmentResults",
                    context.ConsignmentResults.Local.Select(model => new {
                        model.ConsignmentPeriod,
                        model.ConsignorId,
                        model.NumberOfSoldItems,
                        model.TotalValueOfSoldItems,
                        model.NumberOfLostItems,
                        model.TotalValueOfLostItems,
                        model.NumberOfReturnedItems,
                        model.TotalValueOfReturnedItems,
                        model.TotalValueReceivedByConsignor,
                        model.ReturnedDate,
                        model.ReturnedBy
                    }).ToList().Select(x =>
                        new XElement("ConsignmentResult",
                        new XAttribute("ConsignmentPeriod", x.ConsignmentPeriod),
                        new XAttribute("ConsignorId", x.ConsignorId),
                        new XAttribute("NumberOfSoldItems", x.NumberOfSoldItems),
                        new XAttribute("TotalValueOfSoldItems", x.TotalValueOfSoldItems),
                        new XAttribute("NumberOfLostItems", x.NumberOfLostItems),
                        new XAttribute("TotalValueOfLostItems", x.TotalValueOfLostItems),
                        new XAttribute("NumberOfReturnedItems", x.NumberOfReturnedItems),
                        new XAttribute("TotalValueOfReturnedItems", x.TotalValueOfReturnedItems),
                        new XAttribute("TotalValueReceivedByConsignor", x.TotalValueReceivedByConsignor),
                        new XAttribute("ReturnedDate", x.ReturnedDate == null? DateTime.MinValue : x.ReturnedDate),
                        new XAttribute("ReturnedBy", x.ReturnedBy == null? -1 : x.ReturnedBy )
                        )));

                xElement.Save(path);//save to file

                //Backup ExpenseCategories
                context.ExpenseCategories.Load();

                filename = "ExpenseCategories.xml";
                path = Path.GetFullPath(Application.StartupPath + "\\..\\..\\BackupData\\" + filename);

                xElement = new XElement("ExpenseCategories",
                    context.ExpenseCategories.Local.Select(model => new {
                        model.Category,
                        model.Description
                    }).ToList().Select(x =>
                        new XElement("ExpenseCategory",
                        new XAttribute("Category", x.Category),
                        new XAttribute("Description", x.Description == null? "" : x.Description)
                        )));

                xElement.Save(path);//save to file

                //Backup Expenses
                context.Expenses.Load();

                filename = "Expenses.xml";
                path = Path.GetFullPath(Application.StartupPath + "\\..\\..\\BackupData\\" + filename);

                xElement = new XElement("Expenses",
                    context.Expenses.Local.Select(model => new {
                        model.ExpenseId,
                        model.Date,
                        model.Amount,
                        model.Category,
                        model.Note
                    }).ToList().Select(x =>
                        new XElement("Expense",
                        new XAttribute("ExpenseId", x.ExpenseId),
                        new XAttribute("Date", x.Date),
                        new XAttribute("Amount", x.Amount),
                        new XAttribute("Category", x.Category),
                        new XAttribute("Note", x.Note == null ? "" : x.Note)
                        )));

                xElement.Save(path);//save to file

                //Backup Overviews
                context.Overviews.Load();

                filename = "Overviews.xml";
                path = Path.GetFullPath(Application.StartupPath + "\\..\\..\\BackupData\\" + filename);

                xElement = new XElement("Overviews",
                    context.Overviews.Local.Select(model => new {
                        model.Date,
                        model.Budget,
                        model.ClientAsset,
                        model.UsableBudget,
                        model.TotalIncome,
                        model.TotalExpense,
                        model.IncomeOfDate,
                        model.ExpenseOfDate
                    }).ToList().Select(x =>
                        new XElement("Overview",
                        new XAttribute("Date", x.Date),
                        new XAttribute("Budget", x.Budget),
                        new XAttribute("ClientAsset", x.ClientAsset),
                        new XAttribute("UsableBudget", x.UsableBudget),
                        new XAttribute("TotalIncome", x.TotalIncome),
                        new XAttribute("TotalExpense", x.TotalExpense),
                        new XAttribute("IncomeOfDate", x.IncomeOfDate),
                        new XAttribute("ExpenseOfDate", x.ExpenseOfDate)
                        )));

                xElement.Save(path);//save to file
                
                //notify user
                FormHelper.ShowInfoMessageBox("Backup Done!");
            }
            catch
            {
                FormHelper.ShowErrorMessageBox("Cannot Backup Database. Please try again!");
            }
        }

        

        public void RefreshView()
        {
            //run update overview
            ConsignmentStoreBusinessLogic.UpdateOverview();
            DisplayOverview();
        }

        private void DisplayOverview()
        {
            decimal[] totalIncomes = context.Overviews.Local.Select(overview => overview.TotalIncome).ToArray();
            decimal[] totalExpenses = context.Overviews.Local.Select(overview => overview.TotalExpense).ToArray();
            decimal[] usableBudgets = context.Overviews.Local.Select(overview => overview.UsableBudget).ToArray();
            decimal[] clientAssets = context.Overviews.Local.Select(overview => overview.ClientAsset).ToArray();


            //clear all charts
            chartTotalIncomeVsExpense.Series["Total Income"].Points.Clear();
            chartTotalIncomeVsExpense.Series["Total Expense"].Points.Clear();

            chartUsableBudgetVsClientAssest.Series["Usable Budget"].Points.Clear();
            chartUsableBudgetVsClientAssest.Series["Client Asset"].Points.Clear();

            //redraw charts
            for (int i = 1; i < totalIncomes.Length; i++)
            {
                chartTotalIncomeVsExpense.Series["Total Income"].Points.AddXY(i, totalIncomes[i]);
                chartTotalIncomeVsExpense.Series["Total Expense"].Points.AddXY(i, totalExpenses[i]);

                chartUsableBudgetVsClientAssest.Series["Usable Budget"].Points.AddXY(i, usableBudgets[i]);
                chartUsableBudgetVsClientAssest.Series["Client Asset"].Points.AddXY(i, clientAssets[i]);
            }

            //update overview textbox
            textBoxOverview.Text = GetOverviewDetails();
        }

        private string GetOverviewDetails()
        {
            StringBuilder stringBuilder = new StringBuilder();

            Overview overview = context.Overviews.Local.OrderByDescending(o => o.Date).Take(1).ToArray()[0];
            stringBuilder.AppendLine(string.Format("{0,-20} {1}", "Overview",
                ((DateTime)overview.Date).ToString("dd MMMM yyyy")));
            stringBuilder.AppendLine();
            stringBuilder.AppendLine(string.Format("{0,-20} {1:c}", "Budget",
                overview.Budget));
            stringBuilder.AppendLine(string.Format("{0,-20} {1:c}", "Client Asset",
                overview.ClientAsset));
            stringBuilder.AppendLine(string.Format("{0,-20} {1:c}", "Usable Budget",
                overview.UsableBudget));
            stringBuilder.AppendLine();
            stringBuilder.AppendLine(string.Format("{0,-20} {1:c}", "Total Income",
                overview.TotalIncome));
            stringBuilder.AppendLine(string.Format("{0,-20} {1:c}", "Total Expense",
                overview.TotalExpense));
            stringBuilder.AppendLine();
            stringBuilder.AppendLine(string.Format("{0,-20} {1:c}", "Today Income",
                overview.IncomeOfDate));
            stringBuilder.AppendLine(string.Format("{0,-20} {1:c}", "Today Expense",
                overview.ExpenseOfDate));

            return stringBuilder.ToString();
        }
    }
}
