using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CH05_GameOfLife
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
    {
        private readonly Grid _mainGrid;
        private readonly DispatcherTimer _timer;
        private int _genCounter;
        private AdWindow _adWindow;


        public MainWindow()
        {
            InitializeComponent();
            _mainGrid = new Grid(MainCanvas);

            _timer = new DispatcherTimer();
            _timer.Tick += OnTimer;
            _timer.Interval = TimeSpan.FromMilliseconds(200);
        }


        private void StartAd()
        {
            if (_adWindow != null) return;
            _adWindow = new AdWindow(this);
            _adWindow.Closed += AdWindowOnClosed;
            _adWindow.Top = Top + 400;
            _adWindow.Left = Left + 240;
            _adWindow.Show();
        }

        private void AdWindowOnClosed(object sender, EventArgs eventArgs)
        {
            _adWindow.Closed -= AdWindowOnClosed;
            _adWindow = null;
        }


        private void Button_OnClick(object sender, EventArgs e)
        {
            if (!_timer.IsEnabled)
            {
                _timer.Start();
                ButtonStart.Content = "Stop";
                StartAd();
            }
            else
            {
                _timer.Stop();
                ButtonStart.Content = "Start";
            }
        }

        private void OnTimer(object sender, EventArgs e)
        {
            _mainGrid.Update();
            _genCounter++;
            lblGenCount.Content = "Generations: " + _genCounter;
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            _mainGrid.Clear();
        }
    }
}