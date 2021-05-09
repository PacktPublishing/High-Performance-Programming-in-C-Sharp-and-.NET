using System;

namespace CH09_OsiReferenceModel
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			SendMail();
			Console.WriteLine("Email has been sent.");
		}

		static void SendMail()
		{
			EmailServer.SendEmail(
				"FROM_EMAIL"
				, "TO_EMAIL"
				, "CC_EMAIL"
				, "BCC_EMAIL"
				, "Test Message"
				, "Test Body. You can delete!"
			);
		}
	}
}
