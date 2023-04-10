using CreativeIndustries.DS.Contracts;
using CreativeIndustries.DS.DB.EF;
using Microsoft.EntityFrameworkCore;

namespace CreativeIndustries.DS.EF
{
    public class CompanyService : ICompanyService
    {
        private readonly AppDBContext _db;

        public CompanyService(AppDBContext db)
        {
            _db = db;
        }

        public void Create<T>(T item)
        {
            _db.Add(item);
            _db.SaveChanges();
        }

        public void Delete<T>(T item)
        {
            _db.Remove(item);
            _db.SaveChanges();
        }

        public void Update<T>(T item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}


