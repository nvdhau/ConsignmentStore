namespace ConsignmentStoreApp.UserControls
{
    partial class UserControlManageExpenses
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
            this.comboBoxExpenseCategory = new System.Windows.Forms.ComboBox();
            this.buttonAddCategory = new System.Windows.Forms.Button();
            this.dataGridViewExpenses = new System.Windows.Forms.DataGridView();
            this.numericUpDownAmount = new System.Windows.Forms.NumericUpDown();
            this.dateTimePickerExpenseDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxNote = new System.Windows.Forms.TextBox();
            this.labelDateDisplay = new System.Windows.Forms.Label();
            this.labelCategoryDisplay = new System.Windows.Forms.Label();
            this.labelAmountDisplay = new System.Windows.Forms.Label();
            this.labelNoteDisplay = new System.Windows.Forms.Label();
            this.buttonAddExpense = new System.Windows.Forms.Button();
            this.dataGridViewCategories = new System.Windows.Forms.DataGridView();
            this.labelSearchDisplay = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategories)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxExpenseCategory
            // 
            this.comboBoxExpenseCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExpenseCategory.FormattingEnabled = true;
            this.comboBoxExpenseCategory.Location = new System.Drawing.Point(429, 376);
            this.comboBoxExpenseCategory.Name = "comboBoxExpenseCategory";
            this.comboBoxExpenseCategory.Size = new System.Drawing.Size(135, 21);
            this.comboBoxExpenseCategory.TabIndex = 0;
            // 
            // buttonAddCategory
            // 
            this.buttonAddCategory.Location = new System.Drawing.Point(0, 305);
            this.buttonAddCategory.Name = "buttonAddCategory";
            this.buttonAddCategory.Size = new System.Drawing.Size(65, 23);
            this.buttonAddCategory.TabIndex = 1;
            this.buttonAddCategory.Text = "Add";
            this.buttonAddCategory.UseVisualStyleBackColor = true;
            // 
            // dataGridViewExpenses
            // 
            this.dataGridViewExpenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExpenses.Location = new System.Drawing.Point(281, 18);
            this.dataGridViewExpenses.Name = "dataGridViewExpenses";
            this.dataGridViewExpenses.Size = new System.Drawing.Size(469, 281);
            this.dataGridViewExpenses.TabIndex = 2;
            // 
            // numericUpDownAmount
            // 
            this.numericUpDownAmount.DecimalPlaces = 2;
            this.numericUpDownAmount.Location = new System.Drawing.Point(429, 403);
            this.numericUpDownAmount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownAmount.Name = "numericUpDownAmount";
            this.numericUpDownAmount.Size = new System.Drawing.Size(135, 20);
            this.numericUpDownAmount.TabIndex = 4;
            this.numericUpDownAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dateTimePickerExpenseDate
            // 
            this.dateTimePickerExpenseDate.Location = new System.Drawing.Point(429, 350);
            this.dateTimePickerExpenseDate.Name = "dateTimePickerExpenseDate";
            this.dateTimePickerExpenseDate.Size = new System.Drawing.Size(135, 20);
            this.dateTimePickerExpenseDate.TabIndex = 5;
            // 
            // textBoxNote
            // 
            this.textBoxNote.Location = new System.Drawing.Point(613, 350);
            this.textBoxNote.Multiline = true;
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.Size = new System.Drawing.Size(135, 42);
            this.textBoxNote.TabIndex = 6;
            // 
            // labelDateDisplay
            // 
            this.labelDateDisplay.AutoSize = true;
            this.labelDateDisplay.Location = new System.Drawing.Point(375, 356);
            this.labelDateDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDateDisplay.Name = "labelDateDisplay";
            this.labelDateDisplay.Size = new System.Drawing.Size(30, 13);
            this.labelDateDisplay.TabIndex = 7;
            this.labelDateDisplay.Text = "Date";
            // 
            // labelCategoryDisplay
            // 
            this.labelCategoryDisplay.AutoSize = true;
            this.labelCategoryDisplay.Location = new System.Drawing.Point(356, 379);
            this.labelCategoryDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCategoryDisplay.Name = "labelCategoryDisplay";
            this.labelCategoryDisplay.Size = new System.Drawing.Size(49, 13);
            this.labelCategoryDisplay.TabIndex = 8;
            this.labelCategoryDisplay.Text = "Category";
            // 
            // labelAmountDisplay
            // 
            this.labelAmountDisplay.AutoSize = true;
            this.labelAmountDisplay.Location = new System.Drawing.Point(362, 403);
            this.labelAmountDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAmountDisplay.Name = "labelAmountDisplay";
            this.labelAmountDisplay.Size = new System.Drawing.Size(43, 13);
            this.labelAmountDisplay.TabIndex = 9;
            this.labelAmountDisplay.Text = "Amount";
            // 
            // labelNoteDisplay
            // 
            this.labelNoteDisplay.AutoSize = true;
            this.labelNoteDisplay.Location = new System.Drawing.Point(578, 356);
            this.labelNoteDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNoteDisplay.Name = "labelNoteDisplay";
            this.labelNoteDisplay.Size = new System.Drawing.Size(30, 13);
            this.labelNoteDisplay.TabIndex = 10;
            this.labelNoteDisplay.Text = "Note";
            // 
            // buttonAddExpense
            // 
            this.buttonAddExpense.Location = new System.Drawing.Point(613, 400);
            this.buttonAddExpense.Name = "buttonAddExpense";
            this.buttonAddExpense.Size = new System.Drawing.Size(135, 23);
            this.buttonAddExpense.TabIndex = 11;
            this.buttonAddExpense.Text = "Add Expense";
            this.buttonAddExpense.UseVisualStyleBackColor = true;
            // 
            // dataGridViewCategories
            // 
            this.dataGridViewCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCategories.Location = new System.Drawing.Point(0, 18);
            this.dataGridViewCategories.Name = "dataGridViewCategories";
            this.dataGridViewCategories.Size = new System.Drawing.Size(259, 281);
            this.dataGridViewCategories.TabIndex = 12;
            // 
            // labelSearchDisplay
            // 
            this.labelSearchDisplay.AutoSize = true;
            this.labelSearchDisplay.Location = new System.Drawing.Point(279, 306);
            this.labelSearchDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSearchDisplay.Name = "labelSearchDisplay";
            this.labelSearchDisplay.Size = new System.Drawing.Size(109, 13);
            this.labelSearchDisplay.TabIndex = 17;
            this.labelSearchDisplay.Text = "Search by Id or Price ";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(388, 303);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(100, 20);
            this.textBoxSearch.TabIndex = 16;
            // 
            // UserControlManageExpenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelSearchDisplay);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.dataGridViewCategories);
            this.Controls.Add(this.buttonAddExpense);
            this.Controls.Add(this.labelNoteDisplay);
            this.Controls.Add(this.labelAmountDisplay);
            this.Controls.Add(this.labelCategoryDisplay);
            this.Controls.Add(this.labelDateDisplay);
            this.Controls.Add(this.textBoxNote);
            this.Controls.Add(this.dateTimePickerExpenseDate);
            this.Controls.Add(this.numericUpDownAmount);
            this.Controls.Add(this.dataGridViewExpenses);
            this.Controls.Add(this.buttonAddCategory);
            this.Controls.Add(this.comboBoxExpenseCategory);
            this.Name = "UserControlManageExpenses";
            this.Size = new System.Drawing.Size(750, 425);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpenses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategories)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxExpenseCategory;
        private System.Windows.Forms.Button buttonAddCategory;
        private System.Windows.Forms.DataGridView dataGridViewExpenses;
        private System.Windows.Forms.NumericUpDown numericUpDownAmount;
        private System.Windows.Forms.DateTimePicker dateTimePickerExpenseDate;
        private System.Windows.Forms.TextBox textBoxNote;
        private System.Windows.Forms.Label labelDateDisplay;
        private System.Windows.Forms.Label labelCategoryDisplay;
        private System.Windows.Forms.Label labelAmountDisplay;
        private System.Windows.Forms.Label labelNoteDisplay;
        private System.Windows.Forms.Button buttonAddExpense;
        private System.Windows.Forms.DataGridView dataGridViewCategories;
        private System.Windows.Forms.Label labelSearchDisplay;
        private System.Windows.Forms.TextBox textBoxSearch;
    }
}
