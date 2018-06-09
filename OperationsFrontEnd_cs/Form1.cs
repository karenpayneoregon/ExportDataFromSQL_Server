
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Operations;
using OperationsFrontEnd.Classes;

namespace OperationsFrontEnd
{
    public partial class Form1 : Form
    {
        /*
         * Path and file names used in code samples below.
         *
         * If these files exists at pre-build they are removed from the app folder
         * via pre-build command event.
         *
         */
        readonly string _excelCompanyFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Customers.xlsx");
        readonly string _accessCompanyFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database2.accdb");
        readonly string _xmlCompanyFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "customers.xml");

        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Load reference table countries into two ComboBox controls
        /// for allowing selections for exporting to either ms-access
        /// or ms-excel from sql-server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            var ops = new SqlServerOperations();

            countriesComboxExcel.DataSource = ops.CountryList();
            countriesComboxAccess1.DataSource = ops.CountryList("*");

            countriesComboxAccess2.DataSource = new List<CountryItem>((List<CountryItem>)countriesComboxAccess1.DataSource);

            clbColumnNames.DataSource = ops.GetColumnsForTable("Customers");

            if (ops.HasException)
            {
                // disable buttons as they are of no use
                Controls.OfType<Button>().ToList().ForEach(but => but.Enabled = false);
                MessageBox.Show(ops.LastExceptionMessage);
                return;
            }

            countriesComboxExcel.DisplayMember = "Name";
            countriesComboxAccess1.DisplayMember = "Name";
            countriesComboxAccess2.DisplayMember = "Name";

        }
        /// <summary>
        /// Export all customers table records to Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectAllButton_Click(object sender, EventArgs e)
        {
            var ops = new SqlServerOperations();

            if (CreateNewExcelFileCheckBox.Checked)
            {
                if (!(ops.CopyToApplicationFolder(_excelCompanyFileName)))
                {
                    MessageBox.Show(ops.LastExceptionMessage);
                    return;
                }
            }

            int rowCount = 0;

            MessageBox.Show(ops.ExportAllCustomersToExcel(_excelCompanyFileName, ref rowCount)
                ? $"Exported {rowCount} rows."
                : ops.LastExceptionMessage);
        }
        /// <summary>
        /// Export customers table by country to Excel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectByCountryButton_Click(object sender, EventArgs e)
        {

            if (countriesComboxExcel.Text == "Select")
            {
                MessageBox.Show("Please select a country");
                return;
            }

            SqlServerOperations ops = new SqlServerOperations();

            var item = (CountryItem)countriesComboxExcel.SelectedItem;
            string destinationFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{item.Compact}.xlsx");

            if (CreateNewExcelFileCheckBox.Checked)
            {
                if (!(ops.CopyToApplicationFolder(_excelCompanyFileName, destinationFileName)))
                {
                    MessageBox.Show("Copy failed");
                    return;
                }
            }

            int rowCount = 0;
            if (ops.ExportByCountryNameCustomersToExcel(destinationFileName, countriesComboxExcel.Text,ref rowCount))
            {
                MessageBox.Show($"Exported {rowCount} rows.");
            }
            else
            {
                MessageBox.Show(ops.LastExceptionMessage);
            }
        }

        /// <summary>
        /// Export all customer records or by country
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdExportFromSqlServerToMsAccess_Click(object sender, EventArgs e)
        {

            var ops = new SqlServerOperations();
            if (!(ops.CopyToApplicationFolder(_accessCompanyFileName)))
            {
                MessageBox.Show(ops.LastExceptionMessage);
                return;
            }

            int rowCount = 0;

            MessageBox.Show(
                ops.ExportAllCustomersToAccess(_accessCompanyFileName, countriesComboxAccess1.Text, ref rowCount)
                    ? $"Exported {rowCount} rows."
                    : ops.LastExceptionMessage);

        }
        /// <summary>
        /// Export from SQL-Server Customers table selected fields.
        /// The same can be done by writing a method for exporting to Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdExportFromSqlServerToMsAccessDynamic_Click(object sender, EventArgs e)
        {
            var columnList = clbColumnNames.CheckedIColumnDetailsList();
            if (columnList.Count > 0)
            {
                /*
                 * if chkBracketed is checked wrap field names with [], otherwise
                 * use field names without brackets.
                 */
                var fields = chkBracketed.Checked
                    ? string.Join(",", columnList.Select(col => col.NameBracketed))
                    : string.Join(",", columnList.Select(col => col.Name));

                var ops = new SqlServerOperations();

                if (!(ops.CopyToApplicationFolder(_accessCompanyFileName)))
                {
                    MessageBox.Show(ops.LastExceptionMessage);
                    return;
                }

                int rowCount = 0;

                MessageBox.Show(
                    ops.ExportAllCustomersToAccess(_accessCompanyFileName, countriesComboxAccess2.Text, fields, ref rowCount)
                        ? $"Exported {rowCount} rows."
                        : ops.LastExceptionMessage);

            }
            else
            {
                MessageBox.Show("Please select one or more fields and try again");
            }

        }
        /// <summary>
        /// Demonstrates writing customers table to a xml file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdExportToXml_Click(object sender, EventArgs e)
        {

            var ops = new SqlServerOperations();

            // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
            if (ops.WriteCustomerTableToXmlFile(_xmlCompanyFileName))
            {
                MessageBox.Show("Customers data written successfully");
            }
            else
            {
                MessageBox.Show(ops.LastExceptionMessage);
            }

        }


    }
}
