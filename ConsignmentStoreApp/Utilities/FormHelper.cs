using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsignmentStoreApp.Utilities
{
    public static class FormHelper
    {
        /// <summary>
        ///  Initialize default settings for an input dataGridView
        /// </summary>
        /// <param name="dataGridView"></param>
        public static void InitializeDataGridViewSettings(DataGridView dataGridView)
        {
            dataGridView.ReadOnly = true;// no cell editing allowed
            dataGridView.AllowUserToAddRows = false;// no rows can be added 
            dataGridView.AllowUserToDeleteRows = false;// or deleted
            //dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            //dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            //dataGridView.RowHeadersWidth = 30; // shorten the width of the row header
        }

        /// <summary>
        /// Show error message
        /// </summary>
        /// <param name="message"></param>
        public static  void ShowErrorMessageBox(String message, string title = "Input Error")
        {
            // display error message
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Show error message
        /// </summary>
        /// <param name="message"></param>
        public static void ShowInfoMessageBox(String message, string title = "Info")
        {
            // display error message
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
