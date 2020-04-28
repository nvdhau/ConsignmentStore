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
    public partial class UserControlSell : UserControl
    {
        private static UserControlSell instance;
        private ConsignmentStoreEntities context = ConsignmentStoreBusinessLogic.context;
        private List<Item> cartItems = new List<Item>();
        private List<SoldItem> soldItems = new List<SoldItem>();

        public static UserControlSell Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserControlSell();

                return instance;
            }
        }

        public UserControlSell()
        {
            InitializeComponent();

            Load += UserControlSell_Load;
        }

        private void UserControlSell_Load(object sender, EventArgs e)
        {
            FormHelper.InitializeDataGridViewSettings(dataGridViewItems);
            FormHelper.InitializeDataGridViewSettings(dataGridViewSoldItems);

            //binding to dataGridView
            dataGridViewItems.DataSource = context.Items.Local.Where(i => i.ItemStatus.Trim() ==
                                    ConsignmentStoreBusinessLogic.ITEM_STATUS_UNSOLD).ToList();
            dataGridViewItems.Columns["SoldItem"].Visible = false;
            dataGridViewItems.Columns["Employee"].Visible = false;
            dataGridViewItems.Columns["Consignor"].Visible = false;

            dataGridViewSoldItems.DataSource = cartItems.ToList();
            dataGridViewSoldItems.Columns["SoldItem"].Visible = false;
            dataGridViewSoldItems.Columns["Employee"].Visible = false;
            dataGridViewSoldItems.Columns["Consignor"].Visible = false;
            dataGridViewSoldItems.Columns["ConsignedBy"].Visible = false;
            dataGridViewSoldItems.Columns["ItemStatus"].Visible = false;
            dataGridViewSoldItems.Columns["ConsignorId"].Visible = false;
            dataGridViewSoldItems.Columns["ConsignedDate"].Visible = false;

            //double click add to cart
            dataGridViewItems.CellDoubleClick += AddToCart;

            //double click remove from cart
            dataGridViewSoldItems.CellDoubleClick += RemoveFromCart;

            //radio button change
            radioButton0Percent.CheckedChanged += UpdateDiscountAmount;
            radioButton5Percent.CheckedChanged += UpdateDiscountAmount;
            radioButton10Percent.CheckedChanged += UpdateDiscountAmount;

            //search textbox changed - search by id or price
            textBoxSearch.TextChanged += UpdateSearchResults;

            //checkout button
            buttonCheckOut.Click += CheckOut;
        }

        //call when UI is bringing to front
        public void RefreshView()
        {
            dataGridViewItems.DataSource = context.Items.Local.Where(i => i.ItemStatus.Trim() ==
                                    ConsignmentStoreBusinessLogic.ITEM_STATUS_UNSOLD).ToList();
        }

        private void CheckOut(object sender, EventArgs e)
        {
            if (soldItems.Count > 0)
            {
                try
                {
                    //save soldItems to database
                    context.SoldItems.AddRange(soldItems);
                    context.SaveChanges();
                }
                catch
                {
                    FormHelper.ShowErrorMessageBox("Cannot checkout at this time. Please try again!");
                }
                
                //clear cartItems and soldItems
                cartItems.Clear();
                soldItems.Clear();

                //update textboxes
                UpdateCheckOutDetails();

                //update data dataGridViewSoldItems
                dataGridViewSoldItems.DataSource = cartItems.ToList();
            }
            else
                FormHelper.ShowInfoMessageBox("There is nothing to checkout. Please double click from Items in Store to select!");
           
        }

        private void UpdateSearchResults(object sender, EventArgs e)
        {
            string searchString = textBoxSearch.Text.ToString();
            if (searchString != "")
            {
                dataGridViewItems.DataSource = context.Items.Local
                    .Where(i => i.ItemStatus.Trim() ==
                        ConsignmentStoreBusinessLogic.ITEM_STATUS_UNSOLD &&
                        (i.ItemId.ToString().Contains(searchString) ||
                            i.Price.ToString().Contains(searchString))).ToList();
            }
            else
            {
                dataGridViewItems.DataSource = context.Items.Local.Where(i => i.ItemStatus.Trim() ==
                        ConsignmentStoreBusinessLogic.ITEM_STATUS_UNSOLD).ToList();
            }
            dataGridViewItems.Refresh();
        }

        private void RemoveFromCart(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)//not header row
            {
                int itemId = int.Parse(dataGridViewSoldItems.Rows[e.RowIndex].Cells[0].Value.ToString());
                Item item = context.Items.Local.Single(i => i.ItemId == itemId);

                //remove item to cartItems, soldItems
                cartItems.Remove(item);
                soldItems.Remove(soldItems.Find(si => si.ItemId == itemId));

                //show item from local items 
                item.ItemStatus = ConsignmentStoreBusinessLogic.ITEM_STATUS_UNSOLD;
                context.Items.Local.Where(i => i.ItemStatus.Trim() ==
                        ConsignmentStoreBusinessLogic.ITEM_STATUS_UNSOLD);

                //update datagridview
                dataGridViewItems.DataSource = context.Items.Local.Where(i => i.ItemStatus.Trim() ==
                        ConsignmentStoreBusinessLogic.ITEM_STATUS_UNSOLD).ToList();
                dataGridViewSoldItems.DataSource = cartItems.ToList();

                UpdateCheckOutDetails();
            }

        }

        private void UpdateDiscountAmount(object sender, EventArgs e)
        {
            for (int i = 0; i < soldItems.Count; i++)
            {
                soldItems.ElementAt(i).DiscountAmount = Math.Round((cartItems.ElementAt(i).Price * GetDisCountPercent()), 2);
            } 
                
            UpdateCheckOutDetails();
        }

        private void AddToCart(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)//not header row
            {
                int itemId = int.Parse(dataGridViewItems.Rows[e.RowIndex].Cells[0].Value.ToString());
                Item item = context.Items.Local.Single(i => i.ItemId == itemId);
                //mark as sold 
                item.ItemStatus = ConsignmentStoreBusinessLogic.ITEM_STATUS_SOLD; 

                //add item to cartItems, soldItems
                cartItems.Add(item);
                soldItems.Add(new SoldItem
                {
                    ItemId = item.ItemId,
                    SoldBy = ConsignmentStoreBusinessLogic.loggedInEmployee.EmployeeId,
                    SoldDate = DateTime.Now,
                    DiscountAmount = Math.Round((item.Price * GetDisCountPercent()), 2)
                });
                
                //update datagridview
                dataGridViewItems.DataSource = context.Items.Local.Where(i => i.ItemStatus.Trim() ==
                        ConsignmentStoreBusinessLogic.ITEM_STATUS_UNSOLD).ToList();

                dataGridViewSoldItems.DataSource = cartItems.ToList();

                UpdateCheckOutDetails();
            }
        }

        private decimal GetDisCountPercent()
        {
            if (radioButton0Percent.Checked)//0%
                return 0;
            else if (radioButton5Percent.Checked)//5%
                return 0.05m;
            else//10%
                return 0.1m;
        }

        private void UpdateCheckOutDetails()
        {
            //update number of item and total value
            decimal totalValue = cartItems.Sum(i => i.Price);
            textBoxNumberOfItems.Text = cartItems.Count.ToString();
            textBoxTotalValue.Text = "$" + totalValue.ToString("n2");

            //update total and total discount
            decimal totalDiscount = soldItems.Sum(si => si.DiscountAmount);
            textBoxTotalDiscount.Text = "$" + totalDiscount.ToString("n2");
            textBoxTotal.Text = "$" + (totalValue - totalDiscount).ToString("n2");
        }
    }
}
