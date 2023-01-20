namespace CreativeIndustries.DS.Entities
{
    public class CompanyEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EventTime { get; set; }
        public Company Company { get; set; }
    }
}
