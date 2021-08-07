using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace CH11_ResponsiveWPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private int _clickCounter;
		private int _operationNumber;
		private List<Product> _products;
		private int _offset = 0;
		private int _pageSize = 10;
		private int _currentPage = 1;
		BackgroundWorker _worker;

		public MainWindow()
		{
			InitializeComponent();
			BuildCollection();
			SplashWindow splashWindow = new SplashWindow();
			splashWindow.Show();
			for (int x = 1; x <= 100; x++)
			{
				Thread.Sleep(100);
				splashWindow.UpdateProgress(x, $"Progress Update: Performing load operation {x} of 100...");
				DoEvents();
			}
			splashWindow.Close();
			DataTable.ItemsSource = PagedData();
			PageLabel.Content = $"Page {_currentPage} of {PageCount()}";

			_worker = new BackgroundWorker();
			_worker.WorkerReportsProgress = true;
			_worker.WorkerSupportsCancellation = true;
			_worker.DoWork += Worker_DoWork;
			_worker.ProgressChanged += Worker_ProgressChanged;
			_worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
			_worker.RunWorkerAsync();
		}

		private void Worker_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker worker = sender as BackgroundWorker;

			for (int i = 1; i <= 100; i++)
			{
				if (worker.CancellationPending == true)
				{
					e.Cancel = true;
					break;
				}
				else
				{
					// Perform a time consuming operation and report progress.
					_operationNumber = i;
					System.Threading.Thread.Sleep(3000);
					worker.ReportProgress((i / 100) * 100);
				}
			}
		}

		private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			StatusLabel.Content = ($"Progress: {_operationNumber}%");
			TaskProgressBar.Value = _operationNumber;
		}

		private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Cancelled == true)
				StatusLabel.Content = "Cancelled!";
			else if (e.Error != null)
				StatusLabel.Content = "Error: " + e.Error.Message;
			else
				StatusLabel.Content = "Done!";
			Thread.Sleep(1500);
			StatusPanel.Visibility = Visibility.Collapsed;
		}

		private IEnumerable PagedData()
		{
			return _products.GetRange(_offset, _pageSize);
		}

		private void MainWindow_Loaded(object sender, EventArgs e)
		{

		}

		public static void DoEvents()
		{
			Application.Current.Dispatcher.Invoke(DispatcherPriority.Render, new Action(delegate { 
				// Your operation goes here.
			}));
		}

		private void BuildCollection()
		{
			_products = new();
			for (int x = 1; x <= 100; x++)
			{
				_products.Add(new Product { Id = x, Name = $"Product {x}" });
			}
		}

		private int PageCount()
		{
			return _products.Count / _pageSize;
		}

		private void FirstButton_Click(object sender, RoutedEventArgs e)
		{
			if (_currentPage > 1)
			{
				_offset = 0;
				_currentPage = 1;
				PageLabel.Content = $"Page {_currentPage} of {PageCount()}";
				DataTable.ItemsSource = PagedData();
			}
		}

		private void PreviousButton_Click(object sender, RoutedEventArgs e)
		{
			if (_currentPage > 1)
			{
				_offset -= _pageSize;
				_currentPage--;
				PageLabel.Content = $"Page {_currentPage} of {PageCount()}";
				DataTable.ItemsSource = PagedData();
			}
		}

		private void NextButton_Click(object sender, RoutedEventArgs e)
		{
			if (_currentPage < PageCount())
			{
				_offset += _pageSize;
				_currentPage++;
				PageLabel.Content = $"Page {_currentPage} of {PageCount()}";
				DataTable.ItemsSource = PagedData();
			}
		}

		private void LastButton_Click(object sender, RoutedEventArgs e)
		{
			if (_currentPage < PageCount())
			{
				_offset = _products.Count - _pageSize;
				_currentPage = PageCount();
				PageLabel.Content = $"Page {_currentPage} of {PageCount()}";
				DataTable.ItemsSource = PagedData();
			}
		}

		private void IncrementCounterButton_Click(object sender, RoutedEventArgs e)
		{
			_clickCounter++;
			CounterLabel.Content = $"You have clicked the button {_clickCounter} times.";
		}

		private void CancelTaskButton_Click(object sender, RoutedEventArgs e)
		{
			if (_worker.WorkerSupportsCancellation == true)
				_worker.CancelAsync();
		}
	}
}
