using CreativeIndustries.DS.Contracts;
using CreativeIndustries.DS.DB.EF;
using CreativeIndustries.DS.Entities;
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

        public List<T> GetList<T>() where T : class
        {
            List<T> list = _db.Set<T>().ToList();
            return list;
        }

        public Company FindCompById(int id)
        {
            Company item = _db.Companies.Find(id);
            return item;
        }

        public CompanyNews FindNewsById(int id)
        {
            CompanyNews item = _db.News.Find(id);
            return item;
        }

        public CompanyEvent FindEventById(int id)
        {
            CompanyEvent item = _db.Events.Find(id);
            return item;
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


