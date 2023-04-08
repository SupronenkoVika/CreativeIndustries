namespace CreativeIndustries.DS.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public List<CompanyNews> News { get; set; }
        public List<CompanyEvent> Events { get; set; }

    }
}

