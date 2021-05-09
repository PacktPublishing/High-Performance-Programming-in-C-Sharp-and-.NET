namespace CH09_OsiReferenceModel
{
	using System;
	using System.Net.Mail;

	internal class EmailServer
	{
		public static void SendEmail(
			string from,
			string to, 
			string cc, 
			string bcc, 
			string title,
			string message
		)
		{
			try
			{
				MailMessage mailMessage = new MailMessage();
				mailMessage.From = new MailAddress(from);
				mailMessage.To.Add(to);
				mailMessage.To.Add(cc);
				mailMessage.To.Add(bcc);
				mailMessage.Subject = title;
				mailMessage.Body = message;

				SmtpClient smtpServer = new SmtpClient();
				smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
				smtpServer.Host = "smtp-mail.outlook.com";
				smtpServer.Port = 587;
				smtpServer.UseDefaultCredentials = false;
				smtpServer.Credentials = new System.Net.NetworkCredential("EMAIL_ADDRESS", "PASSWORD");
				smtpServer.EnableSsl = true;
				smtpServer.Send(mailMessage);
			}
			catch (Exception ex)
			{
				throw ex.GetBaseException();
			}
		}
	}
}
