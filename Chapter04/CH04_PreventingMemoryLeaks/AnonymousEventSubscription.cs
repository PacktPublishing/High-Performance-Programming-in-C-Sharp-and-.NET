namespace CH04_PreventingMemoryLeaks
{
	using System;
	using System.Diagnostics;

	internal class AnonymousEventSubscription
	{
		public void Login()
		{
			Website website = new Website();

			void LoginHandler(object sender, EventArgs args)
			{
				Debug.WriteLine("Anonymous login event handler using a local method.");
				website.Login -= LoginHandler;
			};

			website.Login += LoginHandler;
			LoginHandler(this, new EventArgs());
		}

		public void Logout()
		{
			Website website = new Website();

			void LogoutHandler(object sender, EventArgs args)
			{
				Debug.WriteLine("Anonymous logout event handler using a local method.");
				website.Logout -= LogoutHandler;
			};

			website.Logout += LogoutHandler;
			LogoutHandler(this, new EventArgs());
		}
	}
}
