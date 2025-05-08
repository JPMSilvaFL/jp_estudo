using System.Net;
using System.Net.Mail;

namespace agenda_api.Services;

public class EmailService {
	public bool SendEmail(string toName,
		string toEmail,
		string subject,
		string body,
		string fromName = "Teste JoãoPedro",
		string fromEmail = "joao.pedro.69461@gmail.com") {
		var smtpClient = new SmtpClient(Configuration.Smtp.Host, Configuration.Smtp.Port);

		smtpClient.Credentials = new NetworkCredential(Configuration.Smtp.UserName, Configuration.Smtp.Password);
		smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
		smtpClient.EnableSsl = true;

		var mail = new MailMessage();

		mail.From = new MailAddress(fromEmail, fromName);
		mail.To.Add(new MailAddress(toEmail, toName));
		mail.Subject = subject;
		mail.Body = body;
		mail.IsBodyHtml = true;

		try {
			smtpClient.Send(mail);
			return true;
		}
		catch {
			return false;
		}
	}
}