namespace CreativeIndustries.DS.Contracts
{
    public interface ICompanyService
    {
        public void Create<T>(T item);
        public void Delete<T>(T item);
    }
}
