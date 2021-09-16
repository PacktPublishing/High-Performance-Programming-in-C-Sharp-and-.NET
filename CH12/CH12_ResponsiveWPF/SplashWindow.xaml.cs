using System.Windows;

namespace CH12_ResponsiveWPF
{
	/// <summary>
	/// Interaction logic for SplashWindow.xaml
	/// </summary>
	public partial class SplashWindow : Window
	{
		public SplashWindow()
		{
			InitializeComponent();
		}

		public void UpdateProgress(int value, string message)
		{
			LoadingProgressBar.Value = value;
			LoadingProgressLabel.Content = message;
			InvalidateVisual();
		}
	}
}
