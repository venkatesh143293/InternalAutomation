using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace WF.Test.AutomationFramework.Helpers
{
    public class ExcelHelpers
    {
        private static List<Datacollection> _dataCol = new List<Datacollection>();
        private static DataTable _table;

        public ExcelHelpers()
        {
        }

        /// <summary>
        /// Storing all the excel values in to the in-memory collections
        /// </summary>
        /// <param name="fileName"></param>
        public static void PopulateInCollection(string fileName, string sheetName="")
        {
            _table = ExcelToDataTable(fileName, sheetName);

            //Iterate through the rows and columns of the Table
            for (int row = 1; row <= _table.Rows.Count; row++)
            {
                for (int col = 0; col < _table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = _table.Columns[col].ColumnName,
                        colValue = _table.Rows[row - 1][col].ToString()
                    };
                    //Add all the details for each row
                    _dataCol.Add(dtTable);
                }
            }
        }

        /*        /// <summary>
                /// Reading all the data from Excelsheet
                /// </summary>
                /// <param name="fileName"></param>
                /// <returns></returns>
                public static DataTable ExcelToDataTable(string fileName)
                {
                    using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = true
                                }
                            }
                            );


                            //Get all the Tables
                            DataTableCollection table = result.Tables;
                            //Store it in DataTable
                            DataTable resultTable = table["Sheet1"];
                            //return
                            return resultTable;
                        }
                    }
                }*/

        /// Convert Excel data to a Datatable
        private static DataTable ExcelToDataTable(string path, string sheetName = "")
        {
            bool hasHeader = true;
            using (var pck = new OfficeOpenXml.ExcelPackage())
            {
                using (var stream = File.OpenRead(path))
                {
                    pck.Load(stream);
                }
                var ws = pck.Workbook.Worksheets.First();
                if (sheetName.Length > 1)
                {
                    ws = pck.Workbook.Worksheets[sheetName];
                }
                
                DataTable tbl = new DataTable();
                foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                {
                    tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                }
                var startRow = hasHeader ? 2 : 1;
                for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                {
                    var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                    DataRow row = tbl.Rows.Add();
                    foreach (var cell in wsRow)
                    {
                        row[cell.Start.Column - 1] = cell.Text;
                    }
                }
                pck.Dispose();
                return tbl;
            }
        }

        /// <summary>
        /// Reading all the data from Excelsheet
        /// </summary>
        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                //Retrieving Data using LINQ to reduce much of iterations
                string data = (from colData in _dataCol
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();

                //var data = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;
                return data.ToString();
            }
            catch (Exception e)
            {
                Reporter.LogFail(e.ToString());
                return null;
            }
        }

        /// <summary>
        /// Get count of rows in excel sheet
        /// </summary>
        public static int GetExcelRowCount()
        {
            return _table.Rows.Count;
        }

        /// <summary>
        /// Method to return excel data as list
        /// </summary>
        public static DataTable excelDataAsList()
        {
            return _table;
        }

    }

    public class Datacollection
    {
        public int rowNumber { get; set; }
        public string colName { get; set; }
        public string colValue { get; set; }
    }



}
