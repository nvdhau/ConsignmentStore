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
using ConsignmentStoreApp.EF_Classes;
using ConsignmentStoreApp.Utilities;

namespace ConsignmentStoreApp.Forms
{
    public partial class AddEditConsignorForm : Form
    {
        Consignor consignor;
        ConsignmentStoreEntities context;


        public AddEditConsignorForm(Consignor consignor)
        {
            InitializeComponent();

            this.consignor = consignor;
            context = ConsignmentStoreBusinessLogic.context;

            //hide minimize and maximize buttons
            MinimizeBox = false;
            MaximizeBox = false;

            if(consignor == null)
            {//Add form
                this.Text = "Add Consignor";
                buttonAddEdit.Text = "Add";
            }
            else
            {//edit form
                this.Text = "Edit Consignor";
                buttonAddEdit.Text = "Update";

                //populate data to form
                textBoxName.Text = consignor.ConsignorName;
                dateTimePickerDOB.Value = (DateTime)consignor.ConsignorDOB;
                textBoxPhone.Text = consignor.ConsignorPhone;
                textBoxEmail.Text = consignor.ConsignorEmail;
            }

            buttonAddEdit.Click += AddEditAConsignor;
        }

        private void AddEditAConsignor(object sender, EventArgs e)
        {
            //validate inputs, not allow empty string
            if(textBoxName.Text.ToString() == "" || textBoxPhone.Text.ToString() == "" ||
                textBoxEmail.Text.ToString() == "")
            {
                FormHelper.ShowErrorMessageBox("Please enter all required fields!");
                return;
            }

            
            if(buttonAddEdit.Text.ToString() == "Add")
            {
                consignor = new Consignor();
                consignor.ConsignorName = textBoxName.Text.ToString();
                consignor.ConsignorDOB = dateTimePickerDOB.Value;
                consignor.ConsignorPhone = textBoxPhone.Text.ToString();
                consignor.ConsignorEmail = textBoxEmail.Text.ToString();

                context.Consignors.Add(consignor);
                try
                {
                    context.SaveChanges();
                }
                catch
                {
                    FormHelper.ShowErrorMessageBox("Cannot add new consignor. Maybe email or phone number are taken. Please try again!");
                    return;
                }
                
            }
            else
            {//Update
                //FormHelper.ShowErrorMessageBox(consignor.ConsignorId+" id");
                consignor.ConsignorName = textBoxName.Text.ToString();
                consignor.ConsignorDOB = dateTimePickerDOB.Value;
                consignor.ConsignorPhone = textBoxPhone.Text.ToString();
                consignor.ConsignorEmail = textBoxEmail.Text.ToString();

                try
                {
                    context.SaveChanges();
                }
                catch
                {
                    FormHelper.ShowErrorMessageBox("Cannot update a consignor. Maybe email or phone number are taken. Please try again!");
                    return;
                }
            }
            
            //success then close the form
            Close();
        }
    }
}
