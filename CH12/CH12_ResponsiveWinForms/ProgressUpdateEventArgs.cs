using System;

namespace CH12_ResponsiveWinForms
{
	public class ProgressUpdateEventArgs : EventArgs
	{
		private int _progressValue;
		private string _progressMessage;

		public ProgressUpdateEventArgs(int value, string message)
		{
			_progressValue = value;
			_progressMessage = message;
		}

		public int Value { get { return _progressValue; } }

		public string Message { get { return _progressMessage; } }
	}
}
