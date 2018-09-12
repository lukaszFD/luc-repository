using System;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using CA_FilledExcelFile.Core;
using System.Collections.Generic;


namespace CA_FilledExcelFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Add();
            Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Excel.Range formatRange;

            try
            {
                uspScript db = new uspScript();
                List<List<string>> rezult = db.script("usp_test", "param", scriptParam.yes);
                int cntPage = Convert.ToInt32(rezult.Count);

                xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, 10]].Merge();

                xlWorkSheet.Cells[1, 1] = "header";

                xlWorkSheet.Cells[2, 1] = "test";
                xlWorkSheet.Cells[2, 2] = "test";
                xlWorkSheet.Cells[2, 3] = "test";
                xlWorkSheet.Cells[2, 4] = "test";
                xlWorkSheet.Cells[2, 5] = "test";
                xlWorkSheet.Cells[2, 6] = "test";
                xlWorkSheet.Cells[2, 7] = "test";
                xlWorkSheet.Cells[2, 8] = "test";
                xlWorkSheet.Cells[2, 9] = "test";
                xlWorkSheet.Cells[2, 10] = "test";

                formatRange = xlWorkSheet.get_Range("j3", "j1000");
                formatRange.NumberFormat = "@";

                formatRange = xlWorkSheet.get_Range("b3", "b1000");
                formatRange.NumberFormat = "@";

                formatRange = xlWorkSheet.get_Range("d3", "d1000");
                formatRange.NumberFormat = "@";

                formatRange = xlWorkSheet.get_Range("e3", "e1000");
                formatRange.NumberFormat = "@";

                for (int i = 0; i < cntPage; i++)
                {
                    xlWorkSheet.Cells[i + 3, 1] = rezult[i][0];
                    xlWorkSheet.Cells[i + 3, 2] = rezult[i][1];
                    xlWorkSheet.Cells[i + 3, 3] = rezult[i][2];
                    xlWorkSheet.Cells[i + 3, 4] = rezult[i][3];
                    xlWorkSheet.Cells[i + 3, 5] = rezult[i][4];
                    xlWorkSheet.Cells[i + 3, 6] = rezult[i][5];
                    xlWorkSheet.Cells[i + 3, 7] = rezult[i][6];
                    xlWorkSheet.Cells[i + 3, 8] = rezult[i][7];
                    xlWorkSheet.Cells[i + 3, 9] = rezult[i][8];
                    xlWorkSheet.Cells[i + 3, 10] = rezult[i][9];
                }

                xlWorkSheet.Columns.AutoFit();
                xlWorkSheet.Rows.AutoFit();

                string date = System.DateTime.Now.ToString(@"yyyy-MM-dd_HH_mm_ss");
                xlApp.ActiveWorkbook.SaveAs(string.Format("yours Path" + @"\Details_{0}_{1}.xlsx", "yours Text", date));
                xlWorkBook.Close();
                xlApp.Quit();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

            Marshal.ReleaseComObject(xlApp);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlWorkSheet);

        }
    }
}
