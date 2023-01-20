using CreativeIndustries.DS.Entities;
using Microsoft.EntityFrameworkCore;

namespace CreativeIndustries.DS.DB.EF
{
    public class CompanyDBContext : DbContext
    {
        public DbSet<Company> Company { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<CompanyEvent> Events { get; set; }
        public DbSet<CompanyNews> News { get; set; }

        public CompanyDBContext(DbContextOptions<CompanyDBContext> options) : base(options)
        {
        }
    }
}

