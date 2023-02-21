using CreativeIndustries.DS.Contracts;
using MailKit.Net.Smtp;
using MimeKit;

namespace CreativeIndustries.DS.EF
{
    public class MailService : IMailService
    {

        public bool Send(MailData mailData)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(mailData.From));
            email.To.Add(MailboxAddress.Parse(mailData.To));
            email.Subject = mailData.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = mailData.Body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(mailData.From, mailData.AppPassword);
            smtp.Send(email);
            smtp.Disconnect(true);
            return true;
        }
    }
}


