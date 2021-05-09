namespace CH02_Excel
{
    using System;
    using Microsoft.Office.Interop.Excel;

    class Program
    {
        static void Main(string[] args)
        {
            var excel = new Application();
            var workbook = excel.Workbooks.Open("C:\\Temp\\LineCount.xlsx");
            var worksheet = excel.ActiveSheet as Worksheet;
            
            Range userRange = worksheet.UsedRange;
            int countRecords = userRange.Rows.Count;
            int add = countRecords + 1;
            worksheet.Cells[add, 1] = $"Total Rows: {countRecords}";

            workbook.Close(true, Type.Missing, Type.Missing);
            excel.Quit();
        }
    }
}
