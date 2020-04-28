namespace ConsignmentStoreApp.UserControls
{
    partial class UserControlConsign
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
            this.textBoxConsignor = new System.Windows.Forms.TextBox();
            this.labelConsignorDisplay = new System.Windows.Forms.Label();
            this.labelConsignedDateDisplay = new System.Windows.Forms.Label();
            this.dateTimePickerConsignedDate = new System.Windows.Forms.DateTimePicker();
            this.labelPriceDisplay = new System.Windows.Forms.Label();
            this.labelRepeatDisplay = new System.Windows.Forms.Label();
            this.buttonAddItems = new System.Windows.Forms.Button();
            this.dataGridViewItems = new System.Windows.Forms.DataGridView();
            this.buttonFinish = new System.Windows.Forms.Button();
            this.textBoxNumberOfItems = new System.Windows.Forms.TextBox();
            this.labelNumberOfItemsDisplay = new System.Windows.Forms.Label();
            this.labelTotalValueDisplay = new System.Windows.Forms.Label();
            this.textBoxTotalValue = new System.Windows.Forms.TextBox();
            this.numericUpDownPrice = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRepeat = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepeat)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxConsignor
            // 
            this.textBoxConsignor.AutoCompleteCustomSource.AddRange(new string[] {
            "abc"});
            this.textBoxConsignor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxConsignor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxConsignor.Location = new System.Drawing.Point(65, 2);
            this.textBoxConsignor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxConsignor.Name = "textBoxConsignor";
            this.textBoxConsignor.Size = new System.Drawing.Size(135, 20);
            this.textBoxConsignor.TabIndex = 0;
            // 
            // labelConsignorDisplay
            // 
            this.labelConsignorDisplay.AutoSize = true;
            this.labelConsignorDisplay.Location = new System.Drawing.Point(7, 4);
            this.labelConsignorDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelConsignorDisplay.Name = "labelConsignorDisplay";
            this.labelConsignorDisplay.Size = new System.Drawing.Size(54, 13);
            this.labelConsignorDisplay.TabIndex = 1;
            this.labelConsignorDisplay.Text = "Consignor";
            // 
            // labelConsignedDateDisplay
            // 
            this.labelConsignedDateDisplay.AutoSize = true;
            this.labelConsignedDateDisplay.Location = new System.Drawing.Point(32, 34);
            this.labelConsignedDateDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelConsignedDateDisplay.Name = "labelConsignedDateDisplay";
            this.labelConsignedDateDisplay.Size = new System.Drawing.Size(30, 13);
            this.labelConsignedDateDisplay.TabIndex = 2;
            this.labelConsignedDateDisplay.Text = "Date";
            // 
            // dateTimePickerConsignedDate
            // 
            this.dateTimePickerConsignedDate.Location = new System.Drawing.Point(65, 29);
            this.dateTimePickerConsignedDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePickerConsignedDate.Name = "dateTimePickerConsignedDate";
            this.dateTimePickerConsignedDate.Size = new System.Drawing.Size(135, 20);
            this.dateTimePickerConsignedDate.TabIndex = 3;
            // 
            // labelPriceDisplay
            // 
            this.labelPriceDisplay.AutoSize = true;
            this.labelPriceDisplay.Location = new System.Drawing.Point(64, 58);
            this.labelPriceDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPriceDisplay.Name = "labelPriceDisplay";
            this.labelPriceDisplay.Size = new System.Drawing.Size(31, 13);
            this.labelPriceDisplay.TabIndex = 5;
            this.labelPriceDisplay.Text = "Price";
            // 
            // labelRepeatDisplay
            // 
            this.labelRepeatDisplay.AutoSize = true;
            this.labelRepeatDisplay.Location = new System.Drawing.Point(145, 58);
            this.labelRepeatDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRepeatDisplay.Name = "labelRepeatDisplay";
            this.labelRepeatDisplay.Size = new System.Drawing.Size(42, 13);
            this.labelRepeatDisplay.TabIndex = 6;
            this.labelRepeatDisplay.Text = "Repeat";
            // 
            // buttonAddItems
            // 
            this.buttonAddItems.Location = new System.Drawing.Point(145, 100);
            this.buttonAddItems.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAddItems.Name = "buttonAddItems";
            this.buttonAddItems.Size = new System.Drawing.Size(53, 23);
            this.buttonAddItems.TabIndex = 7;
            this.buttonAddItems.Text = "Add";
            this.buttonAddItems.UseVisualStyleBackColor = true;
            // 
            // dataGridViewItems
            // 
            this.dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItems.Location = new System.Drawing.Point(211, 2);
            this.dataGridViewItems.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewItems.Name = "dataGridViewItems";
            this.dataGridViewItems.RowTemplate.Height = 28;
            this.dataGridViewItems.Size = new System.Drawing.Size(537, 200);
            this.dataGridViewItems.TabIndex = 9;
            // 
            // buttonFinish
            // 
            this.buttonFinish.Location = new System.Drawing.Point(145, 180);
            this.buttonFinish.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonFinish.Name = "buttonFinish";
            this.buttonFinish.Size = new System.Drawing.Size(53, 23);
            this.buttonFinish.TabIndex = 10;
            this.buttonFinish.Text = "Finish";
            this.buttonFinish.UseVisualStyleBackColor = true;
            // 
            // textBoxNumberOfItems
            // 
            this.textBoxNumberOfItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNumberOfItems.Location = new System.Drawing.Point(145, 154);
            this.textBoxNumberOfItems.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxNumberOfItems.Name = "textBoxNumberOfItems";
            this.textBoxNumberOfItems.ReadOnly = true;
            this.textBoxNumberOfItems.Size = new System.Drawing.Size(54, 20);
            this.textBoxNumberOfItems.TabIndex = 14;
            // 
            // labelNumberOfItemsDisplay
            // 
            this.labelNumberOfItemsDisplay.AutoSize = true;
            this.labelNumberOfItemsDisplay.Location = new System.Drawing.Point(146, 137);
            this.labelNumberOfItemsDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNumberOfItemsDisplay.Name = "labelNumberOfItemsDisplay";
            this.labelNumberOfItemsDisplay.Size = new System.Drawing.Size(49, 13);
            this.labelNumberOfItemsDisplay.TabIndex = 13;
            this.labelNumberOfItemsDisplay.Text = "No Items";
            // 
            // labelTotalValueDisplay
            // 
            this.labelTotalValueDisplay.AutoSize = true;
            this.labelTotalValueDisplay.Location = new System.Drawing.Point(65, 137);
            this.labelTotalValueDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTotalValueDisplay.Name = "labelTotalValueDisplay";
            this.labelTotalValueDisplay.Size = new System.Drawing.Size(61, 13);
            this.labelTotalValueDisplay.TabIndex = 12;
            this.labelTotalValueDisplay.Text = "Total Value";
            // 
            // textBoxTotalValue
            // 
            this.textBoxTotalValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTotalValue.Location = new System.Drawing.Point(67, 154);
            this.textBoxTotalValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxTotalValue.Name = "textBoxTotalValue";
            this.textBoxTotalValue.ReadOnly = true;
            this.textBoxTotalValue.Size = new System.Drawing.Size(67, 20);
            this.textBoxTotalValue.TabIndex = 11;
            // 
            // numericUpDownPrice
            // 
            this.numericUpDownPrice.DecimalPlaces = 2;
            this.numericUpDownPrice.Location = new System.Drawing.Point(65, 74);
            this.numericUpDownPrice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDownPrice.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownPrice.Name = "numericUpDownPrice";
            this.numericUpDownPrice.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownPrice.TabIndex = 15;
            this.numericUpDownPrice.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDownRepeat
            // 
            this.numericUpDownRepeat.Location = new System.Drawing.Point(145, 74);
            this.numericUpDownRepeat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDownRepeat.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRepeat.Name = "numericUpDownRepeat";
            this.numericUpDownRepeat.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownRepeat.TabIndex = 16;
            this.numericUpDownRepeat.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // UserControlConsign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDownRepeat);
            this.Controls.Add(this.numericUpDownPrice);
            this.Controls.Add(this.textBoxNumberOfItems);
            this.Controls.Add(this.labelNumberOfItemsDisplay);
            this.Controls.Add(this.labelTotalValueDisplay);
            this.Controls.Add(this.textBoxTotalValue);
            this.Controls.Add(this.buttonFinish);
            this.Controls.Add(this.dataGridViewItems);
            this.Controls.Add(this.buttonAddItems);
            this.Controls.Add(this.labelRepeatDisplay);
            this.Controls.Add(this.labelPriceDisplay);
            this.Controls.Add(this.dateTimePickerConsignedDate);
            this.Controls.Add(this.labelConsignedDateDisplay);
            this.Controls.Add(this.labelConsignorDisplay);
            this.Controls.Add(this.textBoxConsignor);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UserControlConsign";
            this.Size = new System.Drawing.Size(750, 425);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepeat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxConsignor;
        private System.Windows.Forms.Label labelConsignorDisplay;
        private System.Windows.Forms.Label labelConsignedDateDisplay;
        private System.Windows.Forms.DateTimePicker dateTimePickerConsignedDate;
        private System.Windows.Forms.Label labelPriceDisplay;
        private System.Windows.Forms.Label labelRepeatDisplay;
        private System.Windows.Forms.Button buttonAddItems;
        private System.Windows.Forms.DataGridView dataGridViewItems;
        private System.Windows.Forms.Button buttonFinish;
        private System.Windows.Forms.TextBox textBoxNumberOfItems;
        private System.Windows.Forms.Label labelNumberOfItemsDisplay;
        private System.Windows.Forms.Label labelTotalValueDisplay;
        private System.Windows.Forms.TextBox textBoxTotalValue;
        private System.Windows.Forms.NumericUpDown numericUpDownPrice;
        private System.Windows.Forms.NumericUpDown numericUpDownRepeat;
    }
}
