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
using ConsignmentStoreApp.SeedData;
using ConsignmentStoreApp.Forms;
using ConsignmentStoreApp.Controller;
using ConsignmentStoreApp.UserControls;
using ConsignmentStoreApp.Utilities;

namespace ConsignmentStoreApp
{
    public partial class ConsignmentStoreAppForm : Form
    {
        ConsignmentStoreEntities context;
        Button[] buttons;

        public ConsignmentStoreAppForm()
        {
            InitializeComponent();

            //context = new ConsignmentStoreEntities();
            context = ConsignmentStoreBusinessLogic.context;

            context.Database.Log = (s => Debug.Write(s));

            this.Load += ConsignmentStoreAppForm_Load;
            this.FormClosed += ConsignmentStoreAppForm_FormClosed;

            //get all buttons
            buttons = new Button[]{ buttonManageConsignors, buttonManageEmployees, buttonConsign,
                buttonSell, buttonManageExpenses, buttonConsignmentResults, buttonReturnResults, buttonReports};

            //button handlers
            buttonManageConsignors.Click += ButtonConsignors_Click;
            buttonManageEmployees.Click += ButtonEmployees_Click;
            buttonConsign.Click += ButtonConsign_Click;
            buttonSell.Click += ButtonSell_Click;
            buttonManageExpenses.Click += ButtonManageExpenses_Click;
            buttonConsignmentResults.Click += ButtonConsignmentResults_Click;
            buttonReturnResults.Click += ButtonReturnResults_Click;
            buttonReports.Click += ButtonReports_Click;

            buttonLogout.Click += ButtonLogout_Click;
        }

        private void ButtonLogout_Click(object sender, EventArgs e)
        {
            ConsignmentStoreBusinessLogic.loggedInEmployee = null;//reset loggedInEmployee
            this.Hide();//hide main form
            ShowLoginForm();
        }

        private void ButtonReports_Click(object sender, EventArgs e)
        {
            //hightlight background color of button
            HightlightButtonClicked(buttonReports);

            //prepare data for view
            context.Overviews.Load();

            BringUserControlToFront(UserControlReportsAndBackup.Instance);

            UserControlReportsAndBackup.Instance.RefreshView();
        }

        private void ButtonReturnResults_Click(object sender, EventArgs e)
        {
            //hightlight background color of button
            HightlightButtonClicked(buttonReturnResults);

            //prepare data for view
            context.ConsignmentResults.Where(result => result.ReturnedDate.HasValue == false).Load();

            BringUserControlToFront(UserControlReturn.Instance);
        }

        private void ButtonConsignmentResults_Click(object sender, EventArgs e)
        {
            //hightlight background color of button
            HightlightButtonClicked(buttonConsignmentResults);

            //prepare data for view
            context.ConsignmentSummaries.Load();
            context.ConsignmentResults.Load();

            BringUserControlToFront(UserControlManageConsignmentResults.Instance);
        }

        private void ButtonManageExpenses_Click(object sender, EventArgs e)
        {
            //hightlight background color of button
            HightlightButtonClicked(buttonManageExpenses);

            //prepare data for view
            context.ExpenseCategories.Load();
            context.Expenses.Load();

            BringUserControlToFront(UserControlManageExpenses.Instance);
        }

        private void ButtonSell_Click(object sender, EventArgs e)
        {
            //hightlight background color of button
            HightlightButtonClicked(buttonSell);

            //prepare data for view
            context.Items.Where(item => item.ItemStatus.Trim() ==
                        ConsignmentStoreBusinessLogic.ITEM_STATUS_UNSOLD)
                        .Load();//load unsold items from database

            BringUserControlToFront(UserControlSell.Instance);
            //refresh user view with fresh data
            UserControlSell.Instance.RefreshView();
        }

        private void ButtonConsign_Click(object sender, EventArgs e)
        {
            //hightlight background color of button
            HightlightButtonClicked(buttonConsign);

            //prepare data for consign view
            context.Consignors.Load();

            BringUserControlToFront(UserControlConsign.Instance);
            //refresh user view with fresh data
            UserControlConsign.Instance.RefreshView();
        }

        private void ButtonEmployees_Click(object sender, EventArgs e)
        {
            //hightlight background color of button
            HightlightButtonClicked(buttonManageEmployees);

            FormHelper.ShowErrorMessageBox("Sorry! This function is not available now. It is similar like Manage Consignors");
        }

        private void ButtonConsignors_Click(object sender, EventArgs e)
        {
            //hightlight background color of button
            HightlightButtonClicked(buttonManageConsignors);

            BringUserControlToFront(UserControlManageConsignors.Instance);
        }

        private void BringUserControlToFront(UserControl userControl)
        {
            if (!panelMain.Controls.Contains(userControl))
            {
                panelMain.Controls.Add(userControl);
                userControl.Dock = DockStyle.Fill;
                userControl.BringToFront();
            }
            else
            {
                userControl.BringToFront();
            }
        }

        private void HightlightButtonClicked(Button buttonClicked)
        {
            //reset color all buttons
            foreach (var button in buttons)
            {
                button.BackColor = SystemColors.Control;
            }//highlight buttonClicked
            buttonClicked.BackColor = SystemColors.Info;
        }

        private void ConsignmentStoreAppForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            context.Database.Connection.Close();
            context.Dispose();
        }

        private void ConsignmentStoreAppForm_Load(object sender, EventArgs e)
        {
            //Seed database
            ConsignmentStoreSeedData.SeedDatabase(context);
            this.Hide();//hide main form
            ShowLoginForm();
        }

        private void ShowLoginForm()
        {
            LoginForm loginForm = new LoginForm();

            while (true)
            {
                switch (loginForm.ShowDialog())
                {
                    case DialogResult.Cancel:
                        Close();//exit application
                        return;
                    case DialogResult.OK:
                        //set up UI
                        labelLoggedInEmployee.Text = ConsignmentStoreBusinessLogic.loggedInEmployee.EmployeeEmail.Trim() + " (" +
                            ConsignmentStoreBusinessLogic.loggedInEmployee.EmployeeType.Trim() + ")";

                        if (ConsignmentStoreBusinessLogic.loggedInEmployee.EmployeeType.Trim() == "employee")
                        {//hide some functions
                            buttonManageEmployees.Hide();
                            buttonManageExpenses.Hide();
                            buttonConsignmentResults.Hide();
                            buttonReports.Hide();
                        }else if(ConsignmentStoreBusinessLogic.loggedInEmployee.EmployeeType.Trim() == "admin")
                        {
                            buttonManageEmployees.Show();
                            buttonManageExpenses.Show();
                            buttonConsignmentResults.Show();
                            buttonReports.Show();
                        }

                        //set default UI as Sell
                        ButtonSell_Click(null, EventArgs.Empty);

                        //show main form
                        this.Show();
                        return;
                }
            }
        }
    }
}
