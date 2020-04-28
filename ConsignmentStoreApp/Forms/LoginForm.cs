using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsignmentStoreApp.Controller;

namespace ConsignmentStoreApp.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if(textBoxEmail.Text == "")
            {
                MessageBox.Show("Please enter Email!");
            }
            else if( textBoxPassword.Text == "")
            {
                MessageBox.Show("Please enter Password!");
            }
            else
            {
                switch(ConsignmentStoreBusinessLogic.Authenticate(textBoxEmail.Text, textBoxPassword.Text))
                {
                    case ConsignmentStoreBusinessLogic.INVALID_EMAIL:
                        MessageBox.Show("Please enter INVALID_EMAIL!");
                        break;
                    case ConsignmentStoreBusinessLogic.INVALID_PASSWORD:
                        MessageBox.Show("Please enter INVALID_PASSWORD!");
                        break;
                    case ConsignmentStoreBusinessLogic.VALID:
                        this.DialogResult = DialogResult.OK;
                        this.Dispose();
                        break;
                }
            }
        }
    }
}
