namespace CreativeIndustries.DS.Contracts
{
    public class MailData
    {
        public string From { get; set; }

        public string? To { get; set; }

        public string? Subject { get; set; }

        public string? Body { get; set; }

        public string? AppPassword { get; set; }
    }
}
