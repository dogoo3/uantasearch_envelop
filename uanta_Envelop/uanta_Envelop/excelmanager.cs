using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;

namespace uanta_Envelop
{
    class ExcelManager
    {
        string[,] item;
        Excel.Application excelApp = null;
        Excel.Workbook wb = null;
        Excel.Worksheet ws = null;
        public void MakeWorkSheet(string[,] item, string savepath)
        {
            excelApp = new Excel.Application();
            wb = excelApp.Workbooks.Add();
            ws = wb.Worksheets.get_Item(1) as Excel.Worksheet;

            for(int i=0;i<item.Length/2;i++)
            {
                ws.Cells[i + 1, 1] = item[i, 0];
                ws.Cells[i + 1, 2] = item[i, 1];
            }

            ws.SaveAs(savepath, Excel.XlFileFormat.xlWorkbookDefault);
            wb.Close(true);
            excelApp.Quit();

            ReleaseExcelObject(ws);
            ReleaseExcelObject(wb);
            ReleaseExcelObject(excelApp);
        }

        public string[,] GetWorkSheet(string filepath)
        {
            excelApp = new Excel.Application();

            wb = excelApp.Workbooks.Open(filepath);

            ws = wb.Worksheets.get_Item(1) as Excel.Worksheet;

            Excel.Range rng = ws.UsedRange;

            object[,] data = rng.Value;

            item = new string[data.GetLength(0),3];

            for (int r = 1;r<=data.GetLength(0);r++)
            {
                item[r - 1, 0] = data[r, 1].ToString();
                item[r - 1, 1] = data[r, 2].ToString();
                item[r - 1, 2] = data[r, 3].ToString();
            }

            
            wb.Close();

            ReleaseExcelObject(ws);
            ReleaseExcelObject(wb);
            ReleaseExcelObject(excelApp);
            return item;
        }

        private static void ReleaseExcelObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
