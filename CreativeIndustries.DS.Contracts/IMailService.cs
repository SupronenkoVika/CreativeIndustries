

using CreativeIndustries.API.DXS;

namespace CreativeIndustries.DS.Contracts
{
    public interface IMailService
    {
        public bool Send(MailDataViewModel mailData);
    }
}
