namespace ConsignmentStoreApp.UserControls
{
    partial class UserControlReportsAndBackup
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.buttonBackupData = new System.Windows.Forms.Button();
            this.chartTotalIncomeVsExpense = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartUsableBudgetVsClientAssest = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBoxOverview = new System.Windows.Forms.TextBox();
            this.buttonRestore = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartTotalIncomeVsExpense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartUsableBudgetVsClientAssest)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBackupData
            // 
            this.buttonBackupData.Location = new System.Drawing.Point(489, 393);
            this.buttonBackupData.Name = "buttonBackupData";
            this.buttonBackupData.Size = new System.Drawing.Size(128, 29);
            this.buttonBackupData.TabIndex = 0;
            this.buttonBackupData.Text = "Backup";
            this.buttonBackupData.UseVisualStyleBackColor = true;
            // 
            // chartTotalIncomeVsExpense
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTotalIncomeVsExpense.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.chartTotalIncomeVsExpense.Legends.Add(legend1);
            this.chartTotalIncomeVsExpense.Location = new System.Drawing.Point(0, 0);
            this.chartTotalIncomeVsExpense.Name = "chartTotalIncomeVsExpense";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Total Income";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Total Expense";
            this.chartTotalIncomeVsExpense.Series.Add(series1);
            this.chartTotalIncomeVsExpense.Series.Add(series2);
            this.chartTotalIncomeVsExpense.Size = new System.Drawing.Size(420, 210);
            this.chartTotalIncomeVsExpense.TabIndex = 1;
            this.chartTotalIncomeVsExpense.Text = "chart1";
            // 
            // chartUsableBudgetVsClientAssest
            // 
            chartArea2.Name = "ChartArea1";
            this.chartUsableBudgetVsClientAssest.ChartAreas.Add(chartArea2);
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend2.Name = "Legend1";
            this.chartUsableBudgetVsClientAssest.Legends.Add(legend2);
            this.chartUsableBudgetVsClientAssest.Location = new System.Drawing.Point(0, 212);
            this.chartUsableBudgetVsClientAssest.Name = "chartUsableBudgetVsClientAssest";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Usable Budget";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Client Asset";
            this.chartUsableBudgetVsClientAssest.Series.Add(series3);
            this.chartUsableBudgetVsClientAssest.Series.Add(series4);
            this.chartUsableBudgetVsClientAssest.Size = new System.Drawing.Size(420, 210);
            this.chartUsableBudgetVsClientAssest.TabIndex = 2;
            this.chartUsableBudgetVsClientAssest.Text = "chart1";
            // 
            // textBoxOverview
            // 
            this.textBoxOverview.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOverview.Location = new System.Drawing.Point(436, 0);
            this.textBoxOverview.Multiline = true;
            this.textBoxOverview.Name = "textBoxOverview";
            this.textBoxOverview.ReadOnly = true;
            this.textBoxOverview.Size = new System.Drawing.Size(314, 210);
            this.textBoxOverview.TabIndex = 4;
            // 
            // buttonRestore
            // 
            this.buttonRestore.Location = new System.Drawing.Point(623, 393);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(128, 29);
            this.buttonRestore.TabIndex = 5;
            this.buttonRestore.Text = "Restore";
            this.buttonRestore.UseVisualStyleBackColor = true;
            // 
            // UserControlReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonRestore);
            this.Controls.Add(this.textBoxOverview);
            this.Controls.Add(this.chartUsableBudgetVsClientAssest);
            this.Controls.Add(this.chartTotalIncomeVsExpense);
            this.Controls.Add(this.buttonBackupData);
            this.Name = "UserControlReports";
            this.Size = new System.Drawing.Size(750, 425);
            ((System.ComponentModel.ISupportInitialize)(this.chartTotalIncomeVsExpense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartUsableBudgetVsClientAssest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBackupData;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTotalIncomeVsExpense;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartUsableBudgetVsClientAssest;
        private System.Windows.Forms.TextBox textBoxOverview;
        private System.Windows.Forms.Button buttonRestore;
    }
}
