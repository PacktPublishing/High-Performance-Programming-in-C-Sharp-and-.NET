namespace CH12_ResponsiveMAUI;

using CH12_ResponsiveMAUI.Data;
using CH12_ResponsiveMAUI.Models;
using Microsoft.Maui.ApplicationModel.Communication;
using System.ComponentModel;
using System.Threading;

public partial class SplashPage : ContentPage, INotifyPropertyChanged
{
    Timer _timer;
    double _progress;

    public event PropertyChangedEventHandler PropertyChanged;

    public SplashPage()
	{
		InitializeComponent();
        _timer = new Timer(new TimerCallback((s) => ReportProgress()), null, TimeSpan.Zero, TimeSpan.FromSeconds(3));
    }

    ~SplashPage() => _timer.Dispose();

    private void ReportProgress()
    {
        _timer.Dispose();

        Task.Run(() =>
        {
            // Run code here

            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(250);
                _progress = (double)i / 100;
                SafeInvokeInMainThread(UpdateProgress);
            }
            SafeInvokeInMainThread(LoadMainPage);
        });
    }

    private void LoadMainPage()
    {
        Application.Current.MainPage = new AppShell(new BaseEntity() { Id = 1, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
        Shell.Current.GoToAsync("//main");
    }

    private void SafeInvokeInMainThread(Action action)
    {
        if (DeviceInfo.Platform == DevicePlatform.WinUI)
        {
            Application.Current.Dispatcher.Dispatch(action);
        }
        else
        {
            MainThread.BeginInvokeOnMainThread(action);
        }
    }

    private void UpdateProgress()
    {
        LoadingProgressBar.ProgressTo(_progress, 500, Easing.Linear);
        LoadingProgressLabel.Text = $"Progress Update: Performing load operation {(int)(_progress * 100)} of 100...";
    }
}