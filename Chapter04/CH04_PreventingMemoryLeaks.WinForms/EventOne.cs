namespace CH04_PreventingMemoryLeaks.WinForms
{
	using System;
	using System.Threading;

	internal class EventOne
	{
		public event EventHandler OnEventRaised;
		private static int _count;
		
		public static int Count { get { return _count; } }

		public EventOne()
		{
			Interlocked.Increment(ref _count);
		}

		public void RaiseEvent(EventArgs e)
		{
			EventHandler eventHandler = OnEventRaised;
			if (eventHandler != null)
				eventHandler(this, e);
		}

		~EventOne()
		{
			Interlocked.Decrement(ref _count);
		}
	}
}
