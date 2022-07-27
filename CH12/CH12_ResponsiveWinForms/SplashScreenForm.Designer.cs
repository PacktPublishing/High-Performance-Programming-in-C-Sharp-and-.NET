
namespace CH12_ResponsiveWinForms
{
	partial class SplashScreenForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.LoadingProgressBar = new System.Windows.Forms.ProgressBar();
			this.LoadingProgressLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// LoadingProgressBar
			// 
			this.LoadingProgressBar.BackColor = System.Drawing.SystemColors.GrayText;
			this.LoadingProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.LoadingProgressBar.Location = new System.Drawing.Point(0, 419);
			this.LoadingProgressBar.Name = "LoadingProgressBar";
			this.LoadingProgressBar.Size = new System.Drawing.Size(800, 31);
			this.LoadingProgressBar.TabIndex = 0;
			// 
			// LoadingProgressLabel
			// 
			this.LoadingProgressLabel.AutoSize = true;
			this.LoadingProgressLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.LoadingProgressLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.LoadingProgressLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.LoadingProgressLabel.Location = new System.Drawing.Point(0, 382);
			this.LoadingProgressLabel.Margin = new System.Windows.Forms.Padding(8);
			this.LoadingProgressLabel.Name = "LoadingProgressLabel";
			this.LoadingProgressLabel.Padding = new System.Windows.Forms.Padding(8);
			this.LoadingProgressLabel.Size = new System.Drawing.Size(175, 37);
			this.LoadingProgressLabel.TabIndex = 1;
			this.LoadingProgressLabel.Text = "Loading. Please wait...";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label1.Location = new System.Drawing.Point(29, 126);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(607, 59);
			this.label1.TabIndex = 2;
			this.label1.Text = "Responsive WinForms Example";
			// 
			// SplashScreenForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.LoadingProgressLabel);
			this.Controls.Add(this.LoadingProgressBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "SplashScreenForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SplashScreenForm";
			this.Load += new System.EventHandler(this.SplashScreenForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar LoadingProgressBar;
		private System.Windows.Forms.Label LoadingProgressLabel;
		private System.Windows.Forms.Label label1;
	}
}