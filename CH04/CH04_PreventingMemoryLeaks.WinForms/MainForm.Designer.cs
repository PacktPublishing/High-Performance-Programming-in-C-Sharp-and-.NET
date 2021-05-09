
namespace CH04_PreventingMemoryLeaks.WinForms
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
			this.InformationLabel = new System.Windows.Forms.Label();
			this.RaiseEventsButton = new System.Windows.Forms.Button();
			this.ProgressLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// InformationLabel
			// 
			this.InformationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.InformationLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.InformationLabel.Location = new System.Drawing.Point(-2, 9);
			this.InformationLabel.Name = "InformationLabel";
			this.InformationLabel.Size = new System.Drawing.Size(802, 144);
			this.InformationLabel.TabIndex = 0;
			this.InformationLabel.Text = "Information";
			this.InformationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// RaiseEventsButton
			// 
			this.RaiseEventsButton.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.RaiseEventsButton.Location = new System.Drawing.Point(73, 177);
			this.RaiseEventsButton.Name = "RaiseEventsButton";
			this.RaiseEventsButton.Size = new System.Drawing.Size(651, 185);
			this.RaiseEventsButton.TabIndex = 1;
			this.RaiseEventsButton.Text = "Raise Events";
			this.RaiseEventsButton.UseVisualStyleBackColor = true;
			this.RaiseEventsButton.Click += new System.EventHandler(this.RaiseEventsButton_Click);
			// 
			// ProgressLabel
			// 
			this.ProgressLabel.AutoSize = true;
			this.ProgressLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ProgressLabel.Location = new System.Drawing.Point(67, 365);
			this.ProgressLabel.Name = "ProgressLabel";
			this.ProgressLabel.Size = new System.Drawing.Size(109, 32);
			this.ProgressLabel.TabIndex = 2;
			this.ProgressLabel.Text = "Progress:";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.ProgressLabel);
			this.Controls.Add(this.RaiseEventsButton);
			this.Controls.Add(this.InformationLabel);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label InformationLabel;
		private System.Windows.Forms.Button RaiseEventsButton;
		private System.Windows.Forms.Label ProgressLabel;
	}
}

