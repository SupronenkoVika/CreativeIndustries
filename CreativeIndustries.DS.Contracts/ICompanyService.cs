using CreativeIndustries.DS.Entities;

namespace CreativeIndustries.DS.Contracts
{
    public interface ICompanyService
    {
        public void CreateCompany(Company company);
        public void CreateNews(CompanyNews news);
        public void CreateEvent(CompanyEvent compEvent);
        public void DeleteCompany(Company company);
    }
}
