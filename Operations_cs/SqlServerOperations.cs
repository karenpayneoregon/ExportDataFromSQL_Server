using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using BaseLibrary;

namespace Operations
{
    public class SqlServerOperations : BaseSqlServerConnections
    {
        public SqlServerOperations()
        {
            DefaultCatalog = "ExcelExporting";
        }
        /// <summary>
        /// Copy template excel file to app folder
        /// </summary>
        /// <param name="pFileName"></param>
        /// <returns></returns>
        public bool CopyToApplicationFolder(string pFileName)
        {

            try
            {
                File.Copy(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Files\\{Path.GetFileName(pFileName)}"), 
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pFileName), true);

                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        /// <summary>
        /// Copy template file to app folder with a different name
        /// </summary>
        /// <param name="pFileName"></param>
        /// <param name="pTargetFile"></param>
        /// <returns></returns>
        public bool CopyToApplicationFolder(string pFileName, string pTargetFile)
        {

            try
            {
                File.Copy(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Files\\{Path.GetFileName(pFileName)}"), 
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pTargetFile), true);

                return true;

            }
            catch (Exception e)
            {
                mHasException = true;
                mLastException = e;
            }

            return IsSuccessFul;
        }
        /// <summary>
        /// Get columns for table
        /// </summary>
        /// <param name="pTableName"></param>
        /// <returns></returns>
        public List<ColumnDetails> GetColumnsForTable(string pTableName)
        {
            var columnList = new List<ColumnDetails>();

            using (SqlConnection cn = new SqlConnection {ConnectionString = ConnectionString})
            {
                using (SqlCommand cmd = new SqlCommand {Connection = cn})
                {

                    cmd.Parameters.AddWithValue("@TableName", pTableName);
                    cmd.CommandText = "SELECT column_name ,ordinal_position FROM information_schema.columns WHERE table_name = @TableName; ";

                    try
                    {
                        cn.Open();

                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            columnList.Add(new ColumnDetails() { Name = reader.GetString(0), Position = reader.GetInt32(1) });
                        }
                    }
                    catch (Exception e)
                    {
                        mHasException = true;
                        mLastException = e;
                    }
                }
            }

            return columnList;
        }

        /// <summary>
        /// Create a list of countries that has names without spaces
        /// </summary>
        /// <returns></returns>
        public List<CountryItem> CountryList(string pOption = "Select")
        {

            if (!IsKarenMachine && IsKarensDatabaseServer)
            {
                mHasException = true;
                mLastException = new Exception($"Please change the DatabaseServer from '{DatabaseServer}' to your server name!");
            }

            var countryList = new List<CountryItem>
            {
                new CountryItem { Name = pOption }
            };

            using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = "SELECT DISTINCT Country FROM dbo.Customers";

                    cn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            countryList.Add(new CountryItem { Name = reader.GetString(0) });
                        }
                    }
                }

            }

            return countryList;

        }
        /// <summary>
        /// Get list of contact titles, not used
        /// </summary>
        /// <returns></returns>
        public List<string> ContactTitleList()
        {
            var titleList = new List<string> {"Select"};

            using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = "SELECT DISTINCT ContactTitle FROM dbo.Customers";

                    cn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            titleList.Add(reader.GetString(0));
                        }
                    }
                }

            }

            return titleList;

        }
        /// <summary>
        /// Read data from table, not used
        /// </summary>
        /// <returns></returns>
        public DataTable GetCustomers()
        {
            var dt = new DataTable();

            using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = "SELECT id,FirstName,LastName,Address,City,State,ZipCode FROM dbo.Customer";

                    cn.Open();

                    dt.Load(cmd.ExecuteReader());

                }

            }

            return dt;

        }
        /// <summary>
        /// Export Customers table from SQL-Server database into an existing MS-Access table
        /// with the same structure as the SQL-Server database table utilizing a where condition
        /// on country field.
        /// </summary>
        /// <param name="pFileName">ms-access file</param>
        /// <param name="pCountry">Valid country name or * for no where condition</param>
        /// <param name="pRowsExported">Used to return export row count </param>
        /// <returns></returns>
        public bool ExportAllCustomersToAccess(string pFileName, string pCountry, ref int pRowsExported)
        {
            string fields = "CompanyName,ContactName,ContactTitle,Phone";

            using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {

                    /*
                     * If using .mdb use Microsoft.Jet.OLEDB.4.0 rather than Microsoft.ACE.OLEDB.12.0 as the provider name
                     */
                    cmd.CommandText = $"INSERT INTO OPENROWSET('Microsoft.ACE.OLEDB.12.0','{pFileName}';'Admin';''," +
                                      $"'SELECT {fields} FROM Customers') " +
                                      $" SELECT {fields}  " +
                                      " FROM Customers";

                    if (pCountry != "*")
                    {
                        cmd.CommandText = cmd.CommandText + " WHERE Country = @Country";
                        cmd.Parameters.AddWithValue("@Country", pCountry);
                    }

                    try
                    {
                        cn.Open();
                        pRowsExported = cmd.ExecuteNonQuery();

                        return pRowsExported > 0;

                    }
                    catch (Exception e)
                    {
                        mHasException = true;
                        mLastException = e;
                    }
                }
            }

            return IsSuccessFul;
        }
        public bool ExportAllCustomersToAccess(string pFileName, string pCountry, string pFields, ref int pRowsExported)
        {


            using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {

                    /*
                     * If using .mdb use Microsoft.Jet.OLEDB.4.0 rather than Microsoft.ACE.OLEDB.12.0 as the provider name
                     */
                    cmd.CommandText = $"INSERT INTO OPENROWSET('Microsoft.ACE.OLEDB.12.0','{pFileName}';'Admin';''," +
                                      $"'SELECT {pFields} FROM Customers') " +
                                      $" SELECT {pFields}  " +
                                      " FROM Customers";

                    if (pCountry != "*")
                    {
                        cmd.CommandText = cmd.CommandText + " WHERE Country = @Country";
                        cmd.Parameters.AddWithValue("@Country", pCountry);
                    }

                    try
                    {
                        cn.Open();
                        pRowsExported = cmd.ExecuteNonQuery();

                        return pRowsExported > 0;

                    }
                    catch (Exception e)
                    {
                        mHasException = true;
                        mLastException = e;
                    }
                }
            }

            return IsSuccessFul;
        }

        /// <summary>
        /// Export data to Excel
        /// </summary>
        /// <param name="pFileName"></param>
        /// <param name="pRowsExported">Used to return export row count </param>
        /// <returns></returns>
        public bool ExportAllCustomersToExcel(string pFileName, ref int pRowsExported)
        {
            using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {

                    cmd.CommandText = 
                        $"INSERT INTO OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'Excel 12.0;Database={pFileName}'," + 
                        "'SELECT * from [Customers$]') " + 
                        "SELECT CustomerIdentifier,CompanyName,ContactName,ContactTitle," + 
                        "[Address],City,Region,PostalCode,Country,Phone " + 
                        "FROM Customers";

                    cn.Open();

                    try
                    {

                        pRowsExported = cmd.ExecuteNonQuery();
                        return pRowsExported > 0;

                    }
                    catch (Exception e)
                    {
                        mHasException = true;
                        mLastException = e;
                    }
                }
            }

            return IsSuccessFul;
        }
        /// <summary>
        /// Export data to Excel
        /// </summary>
        /// <param name="pFileName"></param>
        /// <param name="pCountry">Name of country for filter</param>
        /// <param name="pRowsExported">If successful will have count of rows exported</param>
        /// <returns></returns>
        public bool ExportByCountryNameCustomersToExcel(string pFileName, string pCountry, ref int pRowsExported)
        {
            using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = $"INSERT INTO OPENROWSET('Microsoft.ACE.OLEDB.12.0','Excel 12.0;Database={pFileName}','SELECT * from [Customers$]') " + 
                                      "SELECT CustomerIdentifier,CompanyName,ContactName,ContactTitle,[Address],City,Region,PostalCode,Country,Phone " + 
                                      "FROM Customers WHERE Country = @Country";

                    cmd.Parameters.AddWithValue("@Country", pCountry);
                    cn.Open();

                    try
                    {

                        pRowsExported = cmd.ExecuteNonQuery();

                        return pRowsExported > 0;

                    }
                    catch (Exception e)
                    {
                        mHasException = true;
                        mLastException = e;
                    }
                }
            }

            return IsSuccessFul;
        }
        /// <summary>
        /// Demonstrates writing customers table to a xml file without using a DataSet
        /// </summary>
        /// <param name="pFileName"></param>
        /// <returns></returns>
        public bool WriteCustomerTableToXmlFile(string pFileName)
        {
            // Using SQL here or in a stored procedure write data to xml
            // table is stored in this variable TempTable

            using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = cn })
                {
                    // replace sql to match the temp table structure
                    string selectStatement = @"
                    SELECT  ( SELECT  Cust.CustomerIdentifier ,
                                        Cust.CompanyName ,
                                        Cust.ContactName ,
                                        Cust.ContactTitle
                                FROM    dbo.Customers AS Cust
                                FOR
                                XML PATH('Customer') ,
                                    TYPE
                            )
                    FOR XML PATH('') ,
                    ROOT('Customers');";

                    cmd.CommandText = selectStatement;

                    try
                    {
                        cn.Open();

                        XmlReader reader = cmd.ExecuteXmlReader();
                        var doc = new XmlDocument();

                        doc.Load(reader);
                        doc.Save(pFileName);
                    }
                    catch (Exception e)
                    {
                        mHasException = true;
                        mLastException = e;
                    }
                }
            }

            return IsSuccessFul;
        }

    }
}
