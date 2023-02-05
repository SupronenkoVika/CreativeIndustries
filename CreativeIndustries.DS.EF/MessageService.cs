using CreativeIndustries.DS.Contracts;

namespace CreativeIndustries.DS.EF
{
    public class MessageService : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
        }
    }
}

