namespace ConsignmentStoreApp.Forms
{
    partial class GenerateConsignmentResultsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelSearchDisplay = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.dataGridViewItems = new System.Windows.Forms.DataGridView();
            this.labelTitleDisplay = new System.Windows.Forms.Label();
            this.buttonFinishGenerateConsignmentResults = new System.Windows.Forms.Button();
            this.labelInstruction = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSearchDisplay
            // 
            this.labelSearchDisplay.AutoSize = true;
            this.labelSearchDisplay.Location = new System.Drawing.Point(7, 332);
            this.labelSearchDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSearchDisplay.Name = "labelSearchDisplay";
            this.labelSearchDisplay.Size = new System.Drawing.Size(117, 13);
            this.labelSearchDisplay.TabIndex = 18;
            this.labelSearchDisplay.Text = "Search by Consignor Id";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(129, 329);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(100, 20);
            this.textBoxSearch.TabIndex = 17;
            // 
            // dataGridViewItems
            // 
            this.dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItems.Location = new System.Drawing.Point(10, 47);
            this.dataGridViewItems.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewItems.Name = "dataGridViewItems";
            this.dataGridViewItems.RowTemplate.Height = 28;
            this.dataGridViewItems.Size = new System.Drawing.Size(778, 273);
            this.dataGridViewItems.TabIndex = 16;
            // 
            // labelTitleDisplay
            // 
            this.labelTitleDisplay.AutoSize = true;
            this.labelTitleDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleDisplay.Location = new System.Drawing.Point(9, 7);
            this.labelTitleDisplay.Name = "labelTitleDisplay";
            this.labelTitleDisplay.Size = new System.Drawing.Size(173, 20);
            this.labelTitleDisplay.TabIndex = 19;
            this.labelTitleDisplay.Text = "Checking Lost Items";
            // 
            // buttonFinishGenerateConsignmentResults
            // 
            this.buttonFinishGenerateConsignmentResults.Location = new System.Drawing.Point(598, 327);
            this.buttonFinishGenerateConsignmentResults.Name = "buttonFinishGenerateConsignmentResults";
            this.buttonFinishGenerateConsignmentResults.Size = new System.Drawing.Size(190, 23);
            this.buttonFinishGenerateConsignmentResults.TabIndex = 20;
            this.buttonFinishGenerateConsignmentResults.Text = "Finish Publish Consignment Results";
            this.buttonFinishGenerateConsignmentResults.UseVisualStyleBackColor = true;
            // 
            // labelInstruction
            // 
            this.labelInstruction.AutoSize = true;
            this.labelInstruction.Location = new System.Drawing.Point(11, 32);
            this.labelInstruction.Name = "labelInstruction";
            this.labelInstruction.Size = new System.Drawing.Size(508, 13);
            this.labelInstruction.TabIndex = 21;
            this.labelInstruction.Text = "List of Returned Items to Consignors (Double-click an item to toggle its status b" +
    "etween \"unsold\" and \"lost\")";
            // 
            // GenerateConsignmentResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 361);
            this.Controls.Add(this.labelInstruction);
            this.Controls.Add(this.buttonFinishGenerateConsignmentResults);
            this.Controls.Add(this.labelTitleDisplay);
            this.Controls.Add(this.labelSearchDisplay);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.dataGridViewItems);
            this.Name = "GenerateConsignmentResultsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generate Consignment Results";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSearchDisplay;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.DataGridView dataGridViewItems;
        private System.Windows.Forms.Label labelTitleDisplay;
        private System.Windows.Forms.Button buttonFinishGenerateConsignmentResults;
        private System.Windows.Forms.Label labelInstruction;
    }
}