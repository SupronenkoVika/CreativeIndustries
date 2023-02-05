namespace CreativeIndustries.DS.Contracts
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}

