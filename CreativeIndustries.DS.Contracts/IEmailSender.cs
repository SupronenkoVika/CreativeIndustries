namespace CreativeIndustries.DS.Contracts
{
    public interface IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string message) { }
    }
}

