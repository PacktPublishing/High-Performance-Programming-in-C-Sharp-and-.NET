namespace CH04_PreventingMemoryLeaks
{
	using Microsoft.Office.Interop.Excel;
	using System;
	using System.Diagnostics;
	using System.IO;
	using System.Runtime.InteropServices;
	using Excel = Microsoft.Office.Interop.Excel;

	internal class UsingExcel
	{
		public void RunExcelExamples()
		{
			for (int i = 0; i < 10; i++)
				NotReleasingExcelComObjects();
			for (int i = 0; i < 10; i++)
				ReleasingExcelComObjects();
		}

		private static void NotReleasingExcelComObjects()
		{
			string filename = @"C:\Temp\BucketList.xlsx";
			Excel.Application application = new Excel.Application();
			application.Visible = false;
			Excel.Workbook workbook = application.Workbooks.Add();
			Excel.Sheets sheets = workbook.Sheets;
			Excel.Worksheet worksheet = (Worksheet)sheets.Add(sheets[1], Type.Missing, Type.Missing, Type.Missing);
			worksheet.Range["A1"].Value = "Bucket List";
			worksheet.Range["A2"].Value = "Visit New Zealand";
			worksheet.Range["A1"].Value = "Visit Australia";
			if (File.Exists(filename))
				File.Delete(filename);
			workbook.SaveAs(filename);
			workbook.Close();
			application.Quit();
		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "Windows only code.")]
		private static void ReleasingExcelComObjects()
		{
			Excel.Application application = null;
			Excel.Workbooks workbooks = null;
			Excel.Workbook workbook = null;
			Excel.Sheets worksheets = null;
			Excel.Worksheet worksheet = null;
			Excel.Range range = null;
			try
			{
				string filename = @"C:\Temp\BucketList.xlsx";
				application = new Excel.Application();
				application.Visible = false;
				workbooks = application.Workbooks;
				workbook = workbooks.Add();
				worksheets = workbook.Sheets;
				worksheet = (Worksheet)worksheets.Add(worksheets[1], Type.Missing, Type.Missing, Type.Missing);
				range = worksheet.Range["A1"];
				range.Value = "Bucket List";
				range = worksheet.Range["A2"];
				range.Value = "Visit New Zealand";
				range = worksheet.Range["A3"];
				range.Value = "Visit Australia";
				if (File.Exists(filename))
					File.Delete(filename);
				workbook.SaveAs(filename);
				workbook.Close();
				application.Quit();
			}
			finally
			{
				if (range != null) Marshal.FinalReleaseComObject(range);
				if (worksheet != null) Marshal.FinalReleaseComObject(worksheet);
				if (worksheets != null) Marshal.FinalReleaseComObject(worksheets);
				if (workbook != null) Marshal.FinalReleaseComObject(workbook);
				if (workbooks != null) Marshal.FinalReleaseComObject(workbooks);
				if (application != null) Marshal.FinalReleaseComObject(application);

				range = null;
				worksheet = null;
				worksheets = null;
				workbook = null;
				worksheets = null;
				application = null;

				GC.Collect();
				GC.WaitForPendingFinalizers();

				Process[] processes = Process.GetProcessesByName("EXCEL");
				foreach (Process process in processes)
					process.Kill();
			}
		}
	}
}
