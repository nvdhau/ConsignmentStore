namespace ConsignmentStoreApp.UserControls
{
    partial class UserControlSell
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewItems = new System.Windows.Forms.DataGridView();
            this.dataGridViewSoldItems = new System.Windows.Forms.DataGridView();
            this.labelItemsDisplay = new System.Windows.Forms.Label();
            this.labelShoppingDisplay = new System.Windows.Forms.Label();
            this.labelSearchDisplay = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.textBoxNumberOfItems = new System.Windows.Forms.TextBox();
            this.labelNumberOfItemsDisplay = new System.Windows.Forms.Label();
            this.labelTotalValueDisplay = new System.Windows.Forms.Label();
            this.textBoxTotalValue = new System.Windows.Forms.TextBox();
            this.labelDiscountDisplay = new System.Windows.Forms.Label();
            this.labelTotalDiscountDisplay = new System.Windows.Forms.Label();
            this.textBoxTotalDiscount = new System.Windows.Forms.TextBox();
            this.labelTotalDisplay = new System.Windows.Forms.Label();
            this.textBoxTotal = new System.Windows.Forms.TextBox();
            this.buttonCheckOut = new System.Windows.Forms.Button();
            this.radioButton0Percent = new System.Windows.Forms.RadioButton();
            this.radioButton5Percent = new System.Windows.Forms.RadioButton();
            this.radioButton10Percent = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSoldItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewItems
            // 
            this.dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItems.Location = new System.Drawing.Point(0, 26);
            this.dataGridViewItems.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewItems.Name = "dataGridViewItems";
            this.dataGridViewItems.RowTemplate.Height = 28;
            this.dataGridViewItems.Size = new System.Drawing.Size(530, 227);
            this.dataGridViewItems.TabIndex = 10;
            // 
            // dataGridViewSoldItems
            // 
            this.dataGridViewSoldItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSoldItems.Location = new System.Drawing.Point(549, 26);
            this.dataGridViewSoldItems.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewSoldItems.Name = "dataGridViewSoldItems";
            this.dataGridViewSoldItems.RowTemplate.Height = 28;
            this.dataGridViewSoldItems.Size = new System.Drawing.Size(201, 227);
            this.dataGridViewSoldItems.TabIndex = 11;
            // 
            // labelItemsDisplay
            // 
            this.labelItemsDisplay.AutoSize = true;
            this.labelItemsDisplay.Location = new System.Drawing.Point(3, 11);
            this.labelItemsDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelItemsDisplay.Name = "labelItemsDisplay";
            this.labelItemsDisplay.Size = new System.Drawing.Size(72, 13);
            this.labelItemsDisplay.TabIndex = 12;
            this.labelItemsDisplay.Text = "Items In Store";
            // 
            // labelShoppingDisplay
            // 
            this.labelShoppingDisplay.AutoSize = true;
            this.labelShoppingDisplay.Location = new System.Drawing.Point(547, 11);
            this.labelShoppingDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelShoppingDisplay.Name = "labelShoppingDisplay";
            this.labelShoppingDisplay.Size = new System.Drawing.Size(74, 13);
            this.labelShoppingDisplay.TabIndex = 13;
            this.labelShoppingDisplay.Text = "Shopping Cart";
            // 
            // labelSearchDisplay
            // 
            this.labelSearchDisplay.AutoSize = true;
            this.labelSearchDisplay.Location = new System.Drawing.Point(-1, 259);
            this.labelSearchDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSearchDisplay.Name = "labelSearchDisplay";
            this.labelSearchDisplay.Size = new System.Drawing.Size(109, 13);
            this.labelSearchDisplay.TabIndex = 15;
            this.labelSearchDisplay.Text = "Search by Id or Price ";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(108, 256);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(100, 20);
            this.textBoxSearch.TabIndex = 14;
            // 
            // textBoxNumberOfItems
            // 
            this.textBoxNumberOfItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNumberOfItems.Location = new System.Drawing.Point(650, 257);
            this.textBoxNumberOfItems.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxNumberOfItems.Name = "textBoxNumberOfItems";
            this.textBoxNumberOfItems.ReadOnly = true;
            this.textBoxNumberOfItems.Size = new System.Drawing.Size(100, 20);
            this.textBoxNumberOfItems.TabIndex = 19;
            this.textBoxNumberOfItems.Text = "0";
            this.textBoxNumberOfItems.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelNumberOfItemsDisplay
            // 
            this.labelNumberOfItemsDisplay.AutoSize = true;
            this.labelNumberOfItemsDisplay.Location = new System.Drawing.Point(548, 261);
            this.labelNumberOfItemsDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNumberOfItemsDisplay.Name = "labelNumberOfItemsDisplay";
            this.labelNumberOfItemsDisplay.Size = new System.Drawing.Size(49, 13);
            this.labelNumberOfItemsDisplay.TabIndex = 18;
            this.labelNumberOfItemsDisplay.Text = "No Items";
            // 
            // labelTotalValueDisplay
            // 
            this.labelTotalValueDisplay.AutoSize = true;
            this.labelTotalValueDisplay.Location = new System.Drawing.Point(548, 287);
            this.labelTotalValueDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTotalValueDisplay.Name = "labelTotalValueDisplay";
            this.labelTotalValueDisplay.Size = new System.Drawing.Size(61, 13);
            this.labelTotalValueDisplay.TabIndex = 17;
            this.labelTotalValueDisplay.Text = "Total Value";
            // 
            // textBoxTotalValue
            // 
            this.textBoxTotalValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTotalValue.Location = new System.Drawing.Point(650, 283);
            this.textBoxTotalValue.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxTotalValue.Name = "textBoxTotalValue";
            this.textBoxTotalValue.ReadOnly = true;
            this.textBoxTotalValue.Size = new System.Drawing.Size(100, 20);
            this.textBoxTotalValue.TabIndex = 16;
            this.textBoxTotalValue.Text = "$0.00";
            this.textBoxTotalValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelDiscountDisplay
            // 
            this.labelDiscountDisplay.AutoSize = true;
            this.labelDiscountDisplay.Location = new System.Drawing.Point(340, 261);
            this.labelDiscountDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDiscountDisplay.Name = "labelDiscountDisplay";
            this.labelDiscountDisplay.Size = new System.Drawing.Size(49, 13);
            this.labelDiscountDisplay.TabIndex = 22;
            this.labelDiscountDisplay.Text = "Discount";
            // 
            // labelTotalDiscountDisplay
            // 
            this.labelTotalDiscountDisplay.AutoSize = true;
            this.labelTotalDiscountDisplay.Location = new System.Drawing.Point(548, 312);
            this.labelTotalDiscountDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTotalDiscountDisplay.Name = "labelTotalDiscountDisplay";
            this.labelTotalDiscountDisplay.Size = new System.Drawing.Size(76, 13);
            this.labelTotalDiscountDisplay.TabIndex = 24;
            this.labelTotalDiscountDisplay.Text = "Total Discount";
            // 
            // textBoxTotalDiscount
            // 
            this.textBoxTotalDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTotalDiscount.Location = new System.Drawing.Point(650, 308);
            this.textBoxTotalDiscount.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxTotalDiscount.Name = "textBoxTotalDiscount";
            this.textBoxTotalDiscount.ReadOnly = true;
            this.textBoxTotalDiscount.Size = new System.Drawing.Size(100, 20);
            this.textBoxTotalDiscount.TabIndex = 23;
            this.textBoxTotalDiscount.Text = "$0.00";
            this.textBoxTotalDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelTotalDisplay
            // 
            this.labelTotalDisplay.AutoSize = true;
            this.labelTotalDisplay.Location = new System.Drawing.Point(548, 337);
            this.labelTotalDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTotalDisplay.Name = "labelTotalDisplay";
            this.labelTotalDisplay.Size = new System.Drawing.Size(31, 13);
            this.labelTotalDisplay.TabIndex = 26;
            this.labelTotalDisplay.Text = "Total";
            // 
            // textBoxTotal
            // 
            this.textBoxTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTotal.Location = new System.Drawing.Point(650, 333);
            this.textBoxTotal.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxTotal.Name = "textBoxTotal";
            this.textBoxTotal.ReadOnly = true;
            this.textBoxTotal.Size = new System.Drawing.Size(100, 20);
            this.textBoxTotal.TabIndex = 25;
            this.textBoxTotal.Text = "$0.00";
            this.textBoxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonCheckOut
            // 
            this.buttonCheckOut.Location = new System.Drawing.Point(551, 358);
            this.buttonCheckOut.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCheckOut.Name = "buttonCheckOut";
            this.buttonCheckOut.Size = new System.Drawing.Size(199, 23);
            this.buttonCheckOut.TabIndex = 28;
            this.buttonCheckOut.Text = "Check Out";
            this.buttonCheckOut.UseVisualStyleBackColor = true;
            // 
            // radioButton0Percent
            // 
            this.radioButton0Percent.AutoSize = true;
            this.radioButton0Percent.Checked = true;
            this.radioButton0Percent.Location = new System.Drawing.Point(393, 259);
            this.radioButton0Percent.Name = "radioButton0Percent";
            this.radioButton0Percent.Size = new System.Drawing.Size(39, 17);
            this.radioButton0Percent.TabIndex = 29;
            this.radioButton0Percent.TabStop = true;
            this.radioButton0Percent.Text = "0%";
            this.radioButton0Percent.UseVisualStyleBackColor = true;
            // 
            // radioButton5Percent
            // 
            this.radioButton5Percent.AutoSize = true;
            this.radioButton5Percent.Location = new System.Drawing.Point(438, 259);
            this.radioButton5Percent.Name = "radioButton5Percent";
            this.radioButton5Percent.Size = new System.Drawing.Size(39, 17);
            this.radioButton5Percent.TabIndex = 30;
            this.radioButton5Percent.Text = "5%";
            this.radioButton5Percent.UseVisualStyleBackColor = true;
            // 
            // radioButton10Percent
            // 
            this.radioButton10Percent.AutoSize = true;
            this.radioButton10Percent.Location = new System.Drawing.Point(483, 259);
            this.radioButton10Percent.Name = "radioButton10Percent";
            this.radioButton10Percent.Size = new System.Drawing.Size(45, 17);
            this.radioButton10Percent.TabIndex = 31;
            this.radioButton10Percent.Text = "10%";
            this.radioButton10Percent.UseVisualStyleBackColor = true;
            // 
            // UserControlSell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radioButton10Percent);
            this.Controls.Add(this.radioButton5Percent);
            this.Controls.Add(this.radioButton0Percent);
            this.Controls.Add(this.buttonCheckOut);
            this.Controls.Add(this.labelTotalDisplay);
            this.Controls.Add(this.textBoxTotal);
            this.Controls.Add(this.labelTotalDiscountDisplay);
            this.Controls.Add(this.textBoxTotalDiscount);
            this.Controls.Add(this.labelDiscountDisplay);
            this.Controls.Add(this.textBoxNumberOfItems);
            this.Controls.Add(this.labelNumberOfItemsDisplay);
            this.Controls.Add(this.labelTotalValueDisplay);
            this.Controls.Add(this.textBoxTotalValue);
            this.Controls.Add(this.labelSearchDisplay);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.labelShoppingDisplay);
            this.Controls.Add(this.labelItemsDisplay);
            this.Controls.Add(this.dataGridViewSoldItems);
            this.Controls.Add(this.dataGridViewItems);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UserControlSell";
            this.Size = new System.Drawing.Size(750, 425);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSoldItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewItems;
        private System.Windows.Forms.DataGridView dataGridViewSoldItems;
        private System.Windows.Forms.Label labelItemsDisplay;
        private System.Windows.Forms.Label labelShoppingDisplay;
        private System.Windows.Forms.Label labelSearchDisplay;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.TextBox textBoxNumberOfItems;
        private System.Windows.Forms.Label labelNumberOfItemsDisplay;
        private System.Windows.Forms.Label labelTotalValueDisplay;
        private System.Windows.Forms.TextBox textBoxTotalValue;
        private System.Windows.Forms.Label labelDiscountDisplay;
        private System.Windows.Forms.Label labelTotalDiscountDisplay;
        private System.Windows.Forms.TextBox textBoxTotalDiscount;
        private System.Windows.Forms.Label labelTotalDisplay;
        private System.Windows.Forms.TextBox textBoxTotal;
        private System.Windows.Forms.Button buttonCheckOut;
        private System.Windows.Forms.RadioButton radioButton0Percent;
        private System.Windows.Forms.RadioButton radioButton5Percent;
        private System.Windows.Forms.RadioButton radioButton10Percent;
    }
}
