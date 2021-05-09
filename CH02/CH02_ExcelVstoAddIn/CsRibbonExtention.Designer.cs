namespace CH02_ExcelVstoAddIn
{
    partial class CsRibbonExtention : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public CsRibbonExtention()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.CsGroup = this.Factory.CreateRibbonGroup();
            this.GetCellValueButton = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.CsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.CsGroup);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // CsGroup
            // 
            this.CsGroup.Items.Add(this.GetCellValueButton);
            this.CsGroup.Label = "C# Group";
            this.CsGroup.Name = "CsGroup";
            // 
            // GetCellValueButton
            // 
            this.GetCellValueButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.GetCellValueButton.Label = "Get Cell Value";
            this.GetCellValueButton.Name = "GetCellValueButton";
            this.GetCellValueButton.ShowImage = true;
            this.GetCellValueButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.GetCellValueButton_Click);
            // 
            // CsRibbonExtention
            // 
            this.Name = "CsRibbonExtention";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.CsRibbonExtention_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.CsGroup.ResumeLayout(false);
            this.CsGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup CsGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton GetCellValueButton;
    }

    partial class ThisRibbonCollection
    {
        internal CsRibbonExtention CsRibbonExtention
        {
            get { return this.GetRibbon<CsRibbonExtention>(); }
        }
    }
}
