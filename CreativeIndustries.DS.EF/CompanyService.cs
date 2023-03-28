using CreativeIndustries.DS.Contracts;
using CreativeIndustries.DS.DB.EF;
using CreativeIndustries.DS.Entities;

namespace CreativeIndustries.DS.EF
{
    public class CompanyService : ICompanyService
    {
        private readonly CompanyDBContext _db;

        public CompanyService(CompanyDBContext db)
        {
            _db = db;
        }

        public void CreateCompany(Company company)
        {
            _db.Add(company);
            _db.SaveChanges();
        }

        public void CreateNews(CompanyNews news)
        {
            _db.Add(news);
            _db.SaveChanges();
        }

        public void CreateEvent(CompanyEvent compEvent)
        {
            _db.Add(compEvent);
            _db.SaveChanges();
        }

        public void DeleteCompany(Company company)
        {
            _db.Remove(company);
            _db.SaveChanges();
        }
    }
}
