using CreativeIndustries.DS.Entities;

namespace CreativeIndustries.DS.Contracts
{
    public interface ICompanyService
    {
        List<T> GetList<T>() where T : class;
        public Company FindCompById(int id);
        public CompanyNews FindNewsById(int id);
        public CompanyEvent FindEventById(int id);
        public void Create<T>(T item);
        public void Delete<T>(T item);
        public void Update<T>(T item);
    }
}
