namespace ConsignmentStoreApp.UserControls
{
    partial class UserControlManageConsignmentResults
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownMonth = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownYear = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonGenerateConsignmentResults = new System.Windows.Forms.Button();
            this.dataGridViewConsignmentResults = new System.Windows.Forms.DataGridView();
            this.dataGridViewConsignmentSummaries = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxConsignmentPeriods = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConsignmentResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConsignmentSummaries)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 385);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Month";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 385);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Year";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 408);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Consignment Period";
            // 
            // numericUpDownMonth
            // 
            this.numericUpDownMonth.Location = new System.Drawing.Point(116, 401);
            this.numericUpDownMonth.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDownMonth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMonth.Name = "numericUpDownMonth";
            this.numericUpDownMonth.Size = new System.Drawing.Size(44, 20);
            this.numericUpDownMonth.TabIndex = 3;
            this.numericUpDownMonth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownYear
            // 
            this.numericUpDownYear.Location = new System.Drawing.Point(159, 401);
            this.numericUpDownYear.Maximum = new decimal(new int[] {
            2200,
            0,
            0,
            0});
            this.numericUpDownYear.Minimum = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.numericUpDownYear.Name = "numericUpDownYear";
            this.numericUpDownYear.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownYear.TabIndex = 4;
            this.numericUpDownYear.Value = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Consignment Period";
            // 
            // buttonGenerateConsignmentResults
            // 
            this.buttonGenerateConsignmentResults.Location = new System.Drawing.Point(233, 398);
            this.buttonGenerateConsignmentResults.Name = "buttonGenerateConsignmentResults";
            this.buttonGenerateConsignmentResults.Size = new System.Drawing.Size(169, 23);
            this.buttonGenerateConsignmentResults.TabIndex = 7;
            this.buttonGenerateConsignmentResults.Text = "Generate Consignment Results";
            this.buttonGenerateConsignmentResults.UseVisualStyleBackColor = true;
            // 
            // dataGridViewConsignmentResults
            // 
            this.dataGridViewConsignmentResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewConsignmentResults.Location = new System.Drawing.Point(0, 31);
            this.dataGridViewConsignmentResults.Name = "dataGridViewConsignmentResults";
            this.dataGridViewConsignmentResults.Size = new System.Drawing.Size(750, 250);
            this.dataGridViewConsignmentResults.TabIndex = 8;
            // 
            // dataGridViewConsignmentSummaries
            // 
            this.dataGridViewConsignmentSummaries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewConsignmentSummaries.Location = new System.Drawing.Point(0, 300);
            this.dataGridViewConsignmentSummaries.Name = "dataGridViewConsignmentSummaries";
            this.dataGridViewConsignmentSummaries.Size = new System.Drawing.Size(750, 80);
            this.dataGridViewConsignmentSummaries.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 283);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Consignment Summary";
            // 
            // comboBoxConsignmentPeriods
            // 
            this.comboBoxConsignmentPeriods.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxConsignmentPeriods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConsignmentPeriods.FormattingEnabled = true;
            this.comboBoxConsignmentPeriods.Location = new System.Drawing.Point(107, 3);
            this.comboBoxConsignmentPeriods.Name = "comboBoxConsignmentPeriods";
            this.comboBoxConsignmentPeriods.Size = new System.Drawing.Size(121, 21);
            this.comboBoxConsignmentPeriods.TabIndex = 12;
            // 
            // UserControlManageConsignmentResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.comboBoxConsignmentPeriods);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridViewConsignmentSummaries);
            this.Controls.Add(this.dataGridViewConsignmentResults);
            this.Controls.Add(this.buttonGenerateConsignmentResults);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDownYear);
            this.Controls.Add(this.numericUpDownMonth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UserControlManageConsignmentResults";
            this.Size = new System.Drawing.Size(753, 425);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConsignmentResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConsignmentSummaries)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownMonth;
        private System.Windows.Forms.NumericUpDown numericUpDownYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonGenerateConsignmentResults;
        private System.Windows.Forms.DataGridView dataGridViewConsignmentResults;
        private System.Windows.Forms.DataGridView dataGridViewConsignmentSummaries;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxConsignmentPeriods;
    }
}
