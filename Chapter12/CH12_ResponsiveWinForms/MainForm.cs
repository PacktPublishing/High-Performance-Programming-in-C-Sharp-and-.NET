using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace CH12_ResponsiveWinForms
{
	public partial class MainForm : Form
	{
		private int _clickCounter;
		private int _operationNumber;
		private List<Product> _products;
		private int _offset = 0;
		private int _pageSize = 10;
		private int _currentPage = 1;

		public MainForm()
		{
			InitializeComponent();
			LongRunningProcessBackgroundWorker.DoWork += LongRunningProcessBackgroundWorker_DoWork;
			LongRunningProcessBackgroundWorker.ProgressChanged += LongRunningProcessBackgroundWorker_ProgressChanged;
			LongRunningProcessBackgroundWorker.RunWorkerCompleted += LongRunningProcessBackgroundWorker_RunWorkerCompleted;
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			BuildCollection();
			SplashScreenForm splashScreen = new SplashScreenForm();
			splashScreen.Show(this);
			for (int x = 1; x <= 100; x++)
			{
				Thread.Sleep(500);
				splashScreen.UpdateProgress(x, $"Progress Update: Performing load operation {x} of 100...");
				Application.DoEvents();
			}
			splashScreen.Close();
			DataTable.DataSource = PagedProducts();
			PageTextBox.Text = $"Page {_currentPage} of {PageCount()}";
			LongRunningProcess();
		}

		private void BuildCollection()
		{
			_products = new();
			for (int x = 1; x <= 100; x++)
			{
				_products.Add(new Product { Id = x, Name = $"Product {x}" });
			}
		}

		private void LongRunningProcess()
		{
			if (LongRunningProcessBackgroundWorker.IsBusy != true)
			{
				LongRunningProcessBackgroundWorker.RunWorkerAsync();
			}
		}

		private void LongRunningProcessBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
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
					System.Threading.Thread.Sleep(100);
					worker.ReportProgress((i / 100) * 100);
				}
			}
		}

		private void LongRunningProcessBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			StatusLabel.Text = ($"Progress: {_operationNumber}%");
			TaskProgressBar.Value = _operationNumber;
			if (_operationNumber == 100)
			{
				Thread.Sleep(100);
				LongRunningOperationCancelButton.Visible = false;
				StatusBar.Visible = false;
			}
		}

		private void LongRunningProcessBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Cancelled == true)
				StatusLabel.Text = "Canceled!";
			else if (e.Error != null)
				StatusLabel.Text = "Error: " + e.Error.Message;
			else
				StatusLabel.Text = "Done!";
		}

		private void LongRunningOperationCancelButton_Click(object sender, EventArgs e)
		{
			if (LongRunningProcessBackgroundWorker.WorkerSupportsCancellation == true)
			{
				// Cancel the asynchronous operation.
				LongRunningProcessBackgroundWorker.CancelAsync();
				LongRunningOperationCancelButton.Visible = false;
				StatusBar.Visible = false;
			}
		}

		private void IncrementCountButton_Click(object sender, EventArgs e)
		{
			_clickCounter++;
			ClickCounterLabel.Text = $"You have clicked the button {_clickCounter} times.";
		}

		private void FirstButton_Click(object sender, EventArgs e)
		{
			if (_currentPage > 1)
			{
				_offset = 0;
				_currentPage = 1;
				PageTextBox.Text = $"Page {_currentPage} of {PageCount()}";
				DataTable.DataSource = PagedProducts();
			}
		}

		private void PreviousButton_Click(object sender, EventArgs e)
		{
			if (_currentPage > 1)
			{
				_offset -= _pageSize;
				_currentPage--;
				PageTextBox.Text = $"Page {_currentPage} of {PageCount()}";
				DataTable.DataSource = PagedProducts();
			}
		}

		private void NextButton_Click(object sender, EventArgs e)
		{
			if (_currentPage < PageCount())
			{
				_offset += _pageSize;
				_currentPage++;
				PageTextBox.Text = $"Page {_currentPage} of {PageCount()}";
				DataTable.DataSource = PagedProducts();
			}
		}

		private void LastButton_Click(object sender, EventArgs e)
		{
			if (_currentPage < PageCount())
			{
				_offset = _products.Count - _pageSize;
				_currentPage = PageCount();
				PageTextBox.Text = $"Page {_currentPage} of {PageCount()}";
				DataTable.DataSource = PagedProducts();
			}
		}

		private int PageCount()
		{
			return _products.Count / _pageSize;
		}

		private List<Product> PagedProducts()
		{
			return _products.GetRange(_offset, _pageSize);
		}
	}
}
