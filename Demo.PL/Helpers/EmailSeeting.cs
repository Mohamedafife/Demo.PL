using Demo.DAL.Entitys;
using System.Net;
using System.Net.Mail;

namespace Demo.PL.Helpers
{
	public static class EmailSeeting
	{
		public static void SendEmail(Email email)
		{
			var Client = new SmtpClient("smtp.gmail.com",587);
			Client.EnableSsl = true;
			Client.Credentials = new NetworkCredential("afifemoha777@gmail.com", "uqoyfzuwwzampoau");
			Client.Send("afifemoha777@gmail.com",email.To,email.Subject,email.Body);
		}
	}
}
