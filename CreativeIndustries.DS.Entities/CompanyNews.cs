namespace CreativeIndustries.DS.Entities
{
    public class CompanyNews
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PublicationDate { get; set; }

        public Company Company { get; set; }
    }
}

