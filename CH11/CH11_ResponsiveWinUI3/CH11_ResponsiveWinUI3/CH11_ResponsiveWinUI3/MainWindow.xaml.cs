using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace CH11_ResponsiveWinUI3
{
	public sealed partial class MainWindow : Window
	{
		private DispatcherTimer _timer;

        public MainWindow()
		{
			InitializeComponent();
			_timer = new();
			_timer.Interval = TimeSpan.FromSeconds(3);
			_timer.Tick += Timer_Tick;
			_timer.Start();
		}

		private async void Timer_Tick(object sender, object e)
		{
			_timer.Stop();
			_timer.Tick -= Timer_Tick;
			await GetWebsitesAsync();
		}

		private List<string> WebsiteLinks()
		{
			List<string> websiteLinks = new();
			ProgressUpdater.Text = "Loading...";
			websiteLinks.Add("https://docs.microsoft.com");
			websiteLinks.Add("https://www.youtube.com");
			websiteLinks.Add("https://www.abovetopsecret.com/index.php");
			websiteLinks.Add("https://dotnet.microsoft.com/apps/aspnet");
			websiteLinks.Add("https://www.packtpub.com/free-learning");
			websiteLinks.Add("https://smile.amazon.com/");
			return websiteLinks;
		}

		private async Task GetWebsitesAsync()
		{
			Dictionary<string, string> websites = new();
			List<Task< Dictionary<string, string> >> tasks = new();

			foreach(string website in WebsiteLinks())
			{
				string contents = await new HttpClient().GetStringAsync(new Uri(website));
				websites.Add(website, contents);
				ProgressUpdater.Text = $"\nURL: {website}, downloaded...";
			}
			ProgressUpdater.Text = "\nLoading completed.";
			await Task.Delay(1000);
			ProgressPanel.Visibility = Visibility.Collapsed;
			HomePanel.Visibility = Visibility.Visible;
		}
	}
}
