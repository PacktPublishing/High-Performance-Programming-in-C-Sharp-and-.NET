using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CH04_PreventingMemoryLeaks.WinForms
{
	public partial class MainForm : Form
	{
		private int _eventOneCount;
		private int _eventTwoCount;

		public MainForm()
		{
			InitializeComponent();
		}

		private void RaiseEventsButton_Click(object sender, EventArgs e)
		{
			NoMemoryLeakMethod(e);
			MemoryLeakMethod(e);
			SetInformationLabelText();
			SetTitleText();
		}

		private void MemoryLeakMethod(EventArgs e)
		{
			int count = 10000;
			for (int x = 0; x < count; x++)
			{
				var eventTwo = new EventTwo(this);
			}
			_eventTwoCount += count;
		}

		private void NoMemoryLeakMethod(EventArgs e)
		{
			int count = 10000;
			for (int x = 0; x < count; x++)
			{
				EventOne eventOne = new EventOne();
				eventOne.OnEventRaised += RaiseEvent;
				eventOne.RaiseEvent(e);
			}
			_eventOneCount += count;
		}

		private void RaiseEvent(object sender, EventArgs e)
		{
			ProgressLabel.Text = $"Event Raised: {DateTime.Now}";
			ProgressLabel.Invalidate();
			ProgressLabel.Update();
		}

		private void SetInformationLabelText()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"Raised Events (No Memory Leak): {_eventOneCount},  Alive Events: {EventOne.Count}");
			sb.AppendLine($"Raised Events (Memory Leak): {_eventTwoCount},  Alive Events: {EventTwo.Count}");
			InformationLabel.Text = sb.ToString();
		}

		private void SetTitleText()
		{
			Text = $"{_eventOneCount}/{EventOne.Count} - {_eventTwoCount}/{EventTwo.Count}";
		}
	}
}
