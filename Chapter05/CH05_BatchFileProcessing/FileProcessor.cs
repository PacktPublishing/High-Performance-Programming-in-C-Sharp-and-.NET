namespace CH05_BatchFileProcessing
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.IO;
	using System.Runtime.InteropServices;
	using System.Windows;

    internal class FileProcessor
    {
        public List<string> FilePaths;
        private string[] _lines;
        public readonly BackgroundWorker Worker;
        private readonly ProgressUpdater _updater;

        #region EmKeyPress

        /// <summary>
        ///  This code is needed for simulation of some UI activity during file processing.
        ///  If a user doesn't interact with the UI during a freeze, there are chances that such
        ///  freeze won't be detected by Timeline Viewer. As the logic of our app doesn't imply user activities
        ///  during file processing, we emulate this activity (few key presses) with the EmKeyPress method.
        ///  In real-life apps this doesn't make any sense as surely you're interested only in freezes 
        ///  occurred during user interaction with the app.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        private void EmKeyPress()
        {
            keybd_event(0x41, 0, 0x0001, 0);
            keybd_event(0x41, 0, 0x0002, 0);
        }

        #endregion

        public FileProcessor()
        {
            _updater = new ProgressUpdater();
            Worker = new BackgroundWorker { WorkerReportsProgress = true };
            Worker.DoWork += ProcessFiles;
        }

        private void ProcessFiles(object sender, DoWorkEventArgs evts)
        {
            try
            {
                _updater.TotalFiles = FilePaths.Count;

                for (var i = 0; i < FilePaths.Count; i++)
                {
                    EmKeyPress();

                    _updater.CurrentFileNmb = i + 1;

                    var path = FilePaths[i];
                    _lines = File.ReadAllLines(path);

                    for (var j = 0; j < _lines.Length; j++)
                    {
                        var line = _lines[j];
                        var stringReverser = new StringReverser(line);
                        _lines[j] = stringReverser.Reverse();

                        // UI Freeze Fix: Change the 5 to 1000.
                        if (j % 5 == 0)
                        {
                            var p = (float)(j + 1) / _lines.Length * 100;
                            Worker.ReportProgress((int)p, _updater);
                        }
                    }

                    File.WriteAllLines(path, _lines);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
