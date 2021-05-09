namespace CH04_PreventingMemoryLeaks
{
	using System;

	internal class Website
	{
		public event EventHandler<EventArgs> Login;
		public event EventHandler<EventArgs> Logout;
	}
}
