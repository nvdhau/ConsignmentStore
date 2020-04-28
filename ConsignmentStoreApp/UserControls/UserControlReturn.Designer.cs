namespace ConsignmentStoreApp.UserControls
{
    partial class UserControlReturn
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
            this.dataGridViewConsignmentResults = new System.Windows.Forms.DataGridView();
            this.labelSearchDisplay = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.labelTitleDisplay = new System.Windows.Forms.Label();
            this.textBoxResultDetail = new System.Windows.Forms.TextBox();
            this.labelResultDetalDisplay = new System.Windows.Forms.Label();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.labelInstruction = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConsignmentResults)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewConsignmentResults
            // 
            this.dataGridViewConsignmentResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewConsignmentResults.Location = new System.Drawing.Point(0, 42);
            this.dataGridViewConsignmentResults.Name = "dataGridViewConsignmentResults";
            this.dataGridViewConsignmentResults.Size = new System.Drawing.Size(750, 214);
            this.dataGridViewConsignmentResults.TabIndex = 9;
            // 
            // labelSearchDisplay
            // 
            this.labelSearchDisplay.AutoSize = true;
            this.labelSearchDisplay.Location = new System.Drawing.Point(0, 264);
            this.labelSearchDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSearchDisplay.Name = "labelSearchDisplay";
            this.labelSearchDisplay.Size = new System.Drawing.Size(226, 13);
            this.labelSearchDisplay.TabIndex = 17;
            this.labelSearchDisplay.Text = "Search by Consignor Id or Consignment Period";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(226, 261);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(100, 20);
            this.textBoxSearch.TabIndex = 16;
            // 
            // labelTitleDisplay
            // 
            this.labelTitleDisplay.AutoSize = true;
            this.labelTitleDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleDisplay.Location = new System.Drawing.Point(-2, 3);
            this.labelTitleDisplay.Name = "labelTitleDisplay";
            this.labelTitleDisplay.Size = new System.Drawing.Size(204, 20);
            this.labelTitleDisplay.TabIndex = 20;
            this.labelTitleDisplay.Text = "Cosignment Results List";
            // 
            // textBoxResultDetail
            // 
            this.textBoxResultDetail.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxResultDetail.Location = new System.Drawing.Point(443, 261);
            this.textBoxResultDetail.Multiline = true;
            this.textBoxResultDetail.Name = "textBoxResultDetail";
            this.textBoxResultDetail.ReadOnly = true;
            this.textBoxResultDetail.Size = new System.Drawing.Size(307, 127);
            this.textBoxResultDetail.TabIndex = 21;
            // 
            // labelResultDetalDisplay
            // 
            this.labelResultDetalDisplay.AutoSize = true;
            this.labelResultDetalDisplay.Location = new System.Drawing.Point(365, 264);
            this.labelResultDetalDisplay.Name = "labelResultDetalDisplay";
            this.labelResultDetalDisplay.Size = new System.Drawing.Size(72, 13);
            this.labelResultDetalDisplay.TabIndex = 22;
            this.labelResultDetalDisplay.Text = "Result Details";
            // 
            // buttonReturn
            // 
            this.buttonReturn.Location = new System.Drawing.Point(443, 394);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(130, 30);
            this.buttonReturn.TabIndex = 23;
            this.buttonReturn.Text = "Return this Result";
            this.buttonReturn.UseVisualStyleBackColor = true;
            // 
            // labelInstruction
            // 
            this.labelInstruction.AutoSize = true;
            this.labelInstruction.Location = new System.Drawing.Point(-1, 26);
            this.labelInstruction.Name = "labelInstruction";
            this.labelInstruction.Size = new System.Drawing.Size(397, 13);
            this.labelInstruction.TabIndex = 24;
            this.labelInstruction.Text = "Double-Click a result to view its detail. Then click Return this Result button to" +
    " finish";
            // 
            // UserControlReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelInstruction);
            this.Controls.Add(this.buttonReturn);
            this.Controls.Add(this.labelResultDetalDisplay);
            this.Controls.Add(this.textBoxResultDetail);
            this.Controls.Add(this.labelTitleDisplay);
            this.Controls.Add(this.labelSearchDisplay);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.dataGridViewConsignmentResults);
            this.Name = "UserControlReturn";
            this.Size = new System.Drawing.Size(750, 425);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConsignmentResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewConsignmentResults;
        private System.Windows.Forms.Label labelSearchDisplay;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label labelTitleDisplay;
        private System.Windows.Forms.TextBox textBoxResultDetail;
        private System.Windows.Forms.Label labelResultDetalDisplay;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.Label labelInstruction;
    }
}
