namespace CH04_PreventingMemoryLeaks.WinForms
{
	using System;
	using System.Threading;
	using System.Windows.Forms;

	internal class EventTwo
	{
		private static int _count;

		public static int Count { get { return _count; } }

		public string Text { get; private set; }

		public EventTwo(Control control)
		{
			Interlocked.Increment(ref _count);
			control.TextChanged += OnTextChanged;
		}

		private void OnTextChanged(object sender, EventArgs eventArgs)
		{
			Text = ((Control)sender).Text;
		}

		~EventTwo()
		{
			Interlocked.Decrement(ref _count);
		}
	}
}
