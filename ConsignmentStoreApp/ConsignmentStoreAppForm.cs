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

namespace ConsignmentStoreApp
{
    public partial class ConsignmentStoreAppForm : Form
    {
        ConsignmentStoreEntities context;
        Employee employee;

        public ConsignmentStoreAppForm()
        {
            InitializeComponent();

            //context = new ConsignmentStoreEntities();
            context = ConsignmentStoreBusinessLogic.context;

            context.Database.Log = (s => Debug.Write(s));

            this.Load += ConsignmentStoreAppForm_Load;
            this.FormClosed += ConsignmentStoreAppForm_FormClosed;
        }

        private void ConsignmentStoreAppForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            context.Database.Connection.Close();
        }

        private void ConsignmentStoreAppForm_Load(object sender, EventArgs e)
        {
            //Seed database
            ConsignmentStoreSeedData.SeedDatabase(context);

            LoginForm loginForm = new LoginForm();
            
            while (true)
            {
                switch (loginForm.ShowDialog())
                {
                    case DialogResult.Cancel:
                        Close();//exit application
                        return;
                    case DialogResult.OK:
                        MessageBox.Show(ConsignmentStoreBusinessLogic.loggedInEmployee.EmployeeEmail + " " + ConsignmentStoreBusinessLogic.loggedInEmployee.EmployeeType);
                        return;
                }
            }
        }
    }
}
