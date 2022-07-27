namespace CH05_BatchFileProcessing
{
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Windows;
	using Microsoft.Win32;

	public partial class MainWindow : Window
    {
        private readonly List<string> _filePaths;
        private readonly FileProcessor _processor;


        public MainWindow()
        {
            InitializeComponent();

            _filePaths = new List<string>();
            _processor = new FileProcessor();
        }

        private void btnSelectFiles_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog;
            GetFileNames(out openFileDialog);
        }

        private void GetFileNames(out OpenFileDialog openFileDialog)
        {
            openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = "Text files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,
                Multiselect = true
            };

            if (openFileDialog.ShowDialog() != true) return;
            foreach (var file in openFileDialog.FileNames)
                _filePaths.Add(file);

            lblProgress.Content = $"{_filePaths.Count} file(s) selected";
            _processor.FilePaths = _filePaths;
            btnProcessFiles.IsEnabled = true;
        }

        private void btnProcessFiles_Click(object sender, RoutedEventArgs e)
        {
            btnProcessFiles.IsEnabled = false;
            btnSelectFiles.IsEnabled = false;

            _processor.Worker.RunWorkerCompleted += ProcessFinished;
            _processor.Worker.ProgressChanged += ProcessInProgress;

            _processor.Worker.RunWorkerAsync();
        }

        private void ProcessInProgress(object sender, ProgressChangedEventArgs e)
        {
            var upd = (ProgressUpdater)e.UserState;
            lblProgress.Content = $"File {upd.CurrentFileNmb} of {upd.TotalFiles}: {e.ProgressPercentage}%";
        }


        private void ProcessFinished(object sender, RunWorkerCompletedEventArgs e)
        {
            lblProgress.Content = "All files were processed succesfully";
            _filePaths.Clear();
            btnSelectFiles.IsEnabled = true;
        }
    }
}
