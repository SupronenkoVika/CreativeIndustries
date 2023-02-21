using CreativeIndustries.DS.Contracts;
using CreativeIndustries.DS.EF.Configuration;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace CreativeIndustries.DS.EF
{
    public class MailService : IMailService
    {
        private readonly MailSettings _settings;

        public MailService(IOptions<MailSettings> settings)
        {
            _settings = settings.Value;
        }

        public bool Send(MailDataViewModel mailData)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_settings.From));
            email.To.Add(MailboxAddress.Parse(mailData.To));
            email.Subject = mailData.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = mailData.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(_settings.Host, _settings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_settings.From, _settings.AppPassword);
            smtp.Send(email);
            smtp.Disconnect(true);
            return true;
        }
    }
}


