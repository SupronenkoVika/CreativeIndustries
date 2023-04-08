using CreativeIndustries.API.DXS;
using CreativeIndustries.DS.Contracts;
using CreativeIndustries.DS.DB.EF;
using CreativeIndustries.DS.EF.Configuration;
using CreativeIndustries.DS.Entities;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace CreativeIndustries.DS.EF
{
    public class MailService : IMailService
    {
        private readonly MailSettings _settings;
        private readonly AppDBContext _db;

        public MailService(IOptions<MailSettings> settings, AppDBContext context)
        {
            _settings = settings.Value;
            _db = context;
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

        public bool SendMailToAllUsers(MailDataViewModel mailData)
        {
            IQueryable<User> allUsers = _db.Users;

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_settings.From));
            foreach (var user in allUsers)
            {
                email.To.Add(MailboxAddress.Parse(user.Email));
            }
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


