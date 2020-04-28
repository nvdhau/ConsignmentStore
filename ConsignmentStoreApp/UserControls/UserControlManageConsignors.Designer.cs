namespace ConsignmentStoreApp.UserControls
{
    partial class UserControlManageConsignors
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
            this.dataGridViewAll = new System.Windows.Forms.DataGridView();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.labelSearchDisplay = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAll)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAll
            // 
            this.dataGridViewAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAll.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewAll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewAll.Name = "dataGridViewAll";
            this.dataGridViewAll.RowTemplate.Height = 28;
            this.dataGridViewAll.Size = new System.Drawing.Size(750, 383);
            this.dataGridViewAll.TabIndex = 0;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(6, 392);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(60, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(580, 397);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(168, 20);
            this.textBoxSearch.TabIndex = 2;
            // 
            // labelSearchDisplay
            // 
            this.labelSearchDisplay.AutoSize = true;
            this.labelSearchDisplay.Location = new System.Drawing.Point(536, 399);
            this.labelSearchDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSearchDisplay.Name = "labelSearchDisplay";
            this.labelSearchDisplay.Size = new System.Drawing.Size(41, 13);
            this.labelSearchDisplay.TabIndex = 3;
            this.labelSearchDisplay.Text = "Search";
            // 
            // UserControlManageConsignors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelSearchDisplay);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.dataGridViewAll);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UserControlManageConsignors";
            this.Size = new System.Drawing.Size(750, 425);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAll)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAll;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label labelSearchDisplay;
    }
}
