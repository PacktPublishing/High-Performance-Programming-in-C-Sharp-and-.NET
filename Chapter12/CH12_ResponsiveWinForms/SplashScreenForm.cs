using System;
using System.Windows.Forms;

namespace CH12_ResponsiveWinForms
{
	public partial class SplashScreenForm : Form
	{
		public SplashScreenForm()
		{
			InitializeComponent();
		}

		private void SplashScreenForm_Load(object sender, EventArgs e)
		{

		}

		public void UpdateProgress(int value, string message)
		{
			LoadingProgressBar.Value = value;
			LoadingProgressLabel.Text = message;
			Invalidate();
		}
	}
}
