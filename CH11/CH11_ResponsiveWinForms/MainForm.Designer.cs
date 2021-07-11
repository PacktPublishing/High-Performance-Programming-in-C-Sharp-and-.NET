
namespace CH11_ResponsiveWinForms
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.LongRunningProcessBackgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.StatusBar = new System.Windows.Forms.StatusStrip();
			this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.TaskProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.LongRunningOperationCancelButton = new System.Windows.Forms.Button();
			this.ClickCounterLabel = new System.Windows.Forms.Label();
			this.IncrementCountButton = new System.Windows.Forms.Button();
			this.DataTable = new System.Windows.Forms.DataGridView();
			this.DataPagingPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.FirstButton = new System.Windows.Forms.Button();
			this.PreviousButton = new System.Windows.Forms.Button();
			this.PageTextBox = new System.Windows.Forms.TextBox();
			this.NextButton = new System.Windows.Forms.Button();
			this.LastButton = new System.Windows.Forms.Button();
			this.CollectionBuilderBackgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.StatusBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DataTable)).BeginInit();
			this.DataPagingPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// LongRunningProcessBackgroundWorker
			// 
			this.LongRunningProcessBackgroundWorker.WorkerReportsProgress = true;
			this.LongRunningProcessBackgroundWorker.WorkerSupportsCancellation = true;
			// 
			// StatusBar
			// 
			this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.TaskProgressBar});
			this.StatusBar.Location = new System.Drawing.Point(0, 428);
			this.StatusBar.Name = "StatusBar";
			this.StatusBar.Size = new System.Drawing.Size(800, 22);
			this.StatusBar.TabIndex = 0;
			this.StatusBar.Text = "InformationsStatusBar";
			// 
			// StatusLabel
			// 
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size(0, 17);
			// 
			// TaskProgressBar
			// 
			this.TaskProgressBar.Name = "TaskProgressBar";
			this.TaskProgressBar.Size = new System.Drawing.Size(100, 16);
			this.TaskProgressBar.Step = 1;
			// 
			// LongRunningOperationCancelButton
			// 
			this.LongRunningOperationCancelButton.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.LongRunningOperationCancelButton.Location = new System.Drawing.Point(0, 405);
			this.LongRunningOperationCancelButton.Name = "LongRunningOperationCancelButton";
			this.LongRunningOperationCancelButton.Size = new System.Drawing.Size(800, 23);
			this.LongRunningOperationCancelButton.TabIndex = 1;
			this.LongRunningOperationCancelButton.Text = "&Cancel long running operation";
			this.LongRunningOperationCancelButton.UseVisualStyleBackColor = true;
			this.LongRunningOperationCancelButton.Click += new System.EventHandler(this.LongRunningOperationCancelButton_Click);
			// 
			// ClickCounterLabel
			// 
			this.ClickCounterLabel.AutoSize = true;
			this.ClickCounterLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.ClickCounterLabel.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ClickCounterLabel.Location = new System.Drawing.Point(0, 0);
			this.ClickCounterLabel.Name = "ClickCounterLabel";
			this.ClickCounterLabel.Size = new System.Drawing.Size(0, 65);
			this.ClickCounterLabel.TabIndex = 2;
			this.ClickCounterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// IncrementCountButton
			// 
			this.IncrementCountButton.Dock = System.Windows.Forms.DockStyle.Top;
			this.IncrementCountButton.Location = new System.Drawing.Point(0, 65);
			this.IncrementCountButton.Name = "IncrementCountButton";
			this.IncrementCountButton.Size = new System.Drawing.Size(800, 23);
			this.IncrementCountButton.TabIndex = 3;
			this.IncrementCountButton.Text = "&Increment Count";
			this.IncrementCountButton.UseVisualStyleBackColor = true;
			this.IncrementCountButton.Click += new System.EventHandler(this.IncrementCountButton_Click);
			// 
			// DataTable
			// 
			this.DataTable.AllowUserToOrderColumns = true;
			this.DataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DataTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DataTable.Location = new System.Drawing.Point(0, 88);
			this.DataTable.Name = "DataTable";
			this.DataTable.RowTemplate.Height = 25;
			this.DataTable.Size = new System.Drawing.Size(800, 317);
			this.DataTable.TabIndex = 4;
			// 
			// DataPagingPanel
			// 
			this.DataPagingPanel.Controls.Add(this.FirstButton);
			this.DataPagingPanel.Controls.Add(this.PreviousButton);
			this.DataPagingPanel.Controls.Add(this.PageTextBox);
			this.DataPagingPanel.Controls.Add(this.NextButton);
			this.DataPagingPanel.Controls.Add(this.LastButton);
			this.DataPagingPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.DataPagingPanel.Location = new System.Drawing.Point(0, 373);
			this.DataPagingPanel.Name = "DataPagingPanel";
			this.DataPagingPanel.Size = new System.Drawing.Size(800, 32);
			this.DataPagingPanel.TabIndex = 5;
			// 
			// FirstButton
			// 
			this.FirstButton.Location = new System.Drawing.Point(3, 3);
			this.FirstButton.Name = "FirstButton";
			this.FirstButton.Size = new System.Drawing.Size(75, 23);
			this.FirstButton.TabIndex = 0;
			this.FirstButton.Text = "|<<";
			this.FirstButton.UseVisualStyleBackColor = true;
			this.FirstButton.Click += new System.EventHandler(this.FirstButton_Click);
			// 
			// PreviousButton
			// 
			this.PreviousButton.Location = new System.Drawing.Point(84, 3);
			this.PreviousButton.Name = "PreviousButton";
			this.PreviousButton.Size = new System.Drawing.Size(75, 23);
			this.PreviousButton.TabIndex = 1;
			this.PreviousButton.Text = "<<";
			this.PreviousButton.UseVisualStyleBackColor = true;
			this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
			// 
			// PageTextBox
			// 
			this.PageTextBox.Location = new System.Drawing.Point(165, 3);
			this.PageTextBox.Name = "PageTextBox";
			this.PageTextBox.Size = new System.Drawing.Size(100, 23);
			this.PageTextBox.TabIndex = 2;
			// 
			// NextButton
			// 
			this.NextButton.Location = new System.Drawing.Point(271, 3);
			this.NextButton.Name = "NextButton";
			this.NextButton.Size = new System.Drawing.Size(75, 23);
			this.NextButton.TabIndex = 3;
			this.NextButton.Text = ">>";
			this.NextButton.UseVisualStyleBackColor = true;
			this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
			// 
			// LastButton
			// 
			this.LastButton.Location = new System.Drawing.Point(352, 3);
			this.LastButton.Name = "LastButton";
			this.LastButton.Size = new System.Drawing.Size(75, 23);
			this.LastButton.TabIndex = 4;
			this.LastButton.Text = ">>|";
			this.LastButton.UseVisualStyleBackColor = true;
			this.LastButton.Click += new System.EventHandler(this.LastButton_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.DataPagingPanel);
			this.Controls.Add(this.DataTable);
			this.Controls.Add(this.IncrementCountButton);
			this.Controls.Add(this.ClickCounterLabel);
			this.Controls.Add(this.LongRunningOperationCancelButton);
			this.Controls.Add(this.StatusBar);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.StatusBar.ResumeLayout(false);
			this.StatusBar.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DataTable)).EndInit();
			this.DataPagingPanel.ResumeLayout(false);
			this.DataPagingPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.ComponentModel.BackgroundWorker LongRunningProcessBackgroundWorker;
		private System.Windows.Forms.StatusStrip StatusBar;
		private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
		private System.Windows.Forms.ToolStripProgressBar TaskProgressBar;
		private System.Windows.Forms.Button LongRunningOperationCancelButton;
		private System.Windows.Forms.Label ClickCounterLabel;
		private System.Windows.Forms.Button IncrementCountButton;
		private System.Windows.Forms.DataGridView DataTable;
		private System.Windows.Forms.FlowLayoutPanel DataPagingPanel;
		private System.Windows.Forms.Button FirstButton;
		private System.Windows.Forms.Button PreviousButton;
		private System.Windows.Forms.TextBox PageTextBox;
		private System.Windows.Forms.Button NextButton;
		private System.Windows.Forms.Button LastButton;
		private System.ComponentModel.BackgroundWorker CollectionBuilderBackgroundWorker;
	}
}

