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
    public partial class UserControlManageExpenses : UserControl
    {
        private static UserControlManageExpenses instance;
        private ConsignmentStoreEntities context = ConsignmentStoreBusinessLogic.context;

        public static UserControlManageExpenses Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserControlManageExpenses();

                return instance;
            }
        }

        public UserControlManageExpenses()
        {
            InitializeComponent();

            Load += UserControlManageExpenses_Load;
        }

        private void UserControlManageExpenses_Load(object sender, EventArgs e)
        {

            //binding datagridview
            FormHelper.InitializeDataGridViewSettings(dataGridViewExpenses);
            FormHelper.InitializeDataGridViewSettings(dataGridViewCategories);

            dataGridViewExpenses.DataSource = context.Expenses.Local.ToBindingList();//binding to dataGridView
            dataGridViewExpenses.Columns["ExpenseCategory"].Visible = false;
            dataGridViewExpenses.Columns[2].DefaultCellStyle.Format = "N2";
            dataGridViewExpenses.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridViewCategories.DataSource = context.ExpenseCategories.Local.ToBindingList();//binding to dataGridView
            dataGridViewCategories.Columns["Expenses"].Visible = false;

            //add categories to combox box
            comboBoxExpenseCategory.Items.AddRange(context.ExpenseCategories.Select(category => category.Category).ToArray());
            comboBoxExpenseCategory.SelectedIndex = comboBoxExpenseCategory.Items.IndexOf("Others");//set default value

            //add expense
            buttonAddExpense.Click += AddExpense;

            //search expense
            textBoxSearch.TextChanged += SearchExpenseByCategoryDateOrNote;
        }

        private void SearchExpenseByCategoryDateOrNote(object sender, EventArgs e)
        {
            string searchString = textBoxSearch.Text.ToString();
            if (searchString != "")
            {
                dataGridViewExpenses.DataSource = context.Expenses.Local
                    .Where(expense =>
                        //search by category
                        expense.Category.Contains(searchString) ||
                        //by Date
                        expense.Date.ToString().Contains(searchString) ||
                        //by note - first check not null
                        (expense.Note != null && expense.Note.ToString().Contains(searchString))
                        ).ToList();
            }
            else
            {//restore default
                dataGridViewExpenses.DataSource = context.Expenses.Local.ToBindingList();
            }
            dataGridViewExpenses.Refresh();
        }

        private void AddExpense(object sender, EventArgs e)
        {
            if(DateTime.Now < dateTimePickerExpenseDate.Value.AddMinutes(60))
            {
                context.Expenses.Local.Add(new Expens
                {
                    Amount = numericUpDownAmount.Value,
                    Category = comboBoxExpenseCategory.SelectedItem.ToString(),
                    Date = dateTimePickerExpenseDate.Value,
                    Note = textBoxNote.Text
                });

                context.SaveChanges();//save to database

                //refresh
                dataGridViewExpenses.Refresh();

                textBoxNote.Text = "";
            }
            else
            {
                FormHelper.ShowErrorMessageBox("Cannot add expense. Please try again!\nNote that Date must not in the past");
            }
            
        }
    }
}
