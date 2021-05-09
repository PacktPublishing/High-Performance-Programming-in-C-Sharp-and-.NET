using System.Globalization;
using System.Threading;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace CH02_ExcelVstoAddIn
{
    public partial class CsRibbonExtention
    {
        private void CsRibbonExtention_Load(object sender, RibbonUIEventArgs e)
        {
            
        }

        private void GetCellValueButton_Click(object sender, RibbonControlEventArgs e)
        {
            CultureInfo originalLanguage = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            var activeCell = Globals.ThisAddIn.Application.ActiveCell;
            if (activeCell.Value2 != null)
                MessageBox.Show(activeCell.Value2.ToString());
            Thread.CurrentThread.CurrentCulture = originalLanguage;
            var ws = new Worksheet();
        }
    }
}
