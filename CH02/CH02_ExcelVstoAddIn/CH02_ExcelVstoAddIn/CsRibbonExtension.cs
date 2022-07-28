namespace CH02_ExcelVstoAddIn
{
    using Microsoft.Office.Tools.Ribbon;
    using System.Globalization;
    using System.Threading;
    using System.Windows.Forms;

    public partial class CsRibbonExtension
    {
        private void CsRibbonExtension_Load(object sender, RibbonUIEventArgs e)
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
        }
    }
}
