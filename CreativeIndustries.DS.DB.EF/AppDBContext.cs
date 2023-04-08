using CreativeIndustries.DS.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CreativeIndustries.DS.DB.EF
{
    public class AppDBContext : IdentityDbContext<User>
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyEvent> Events { get; set; }
        public DbSet<CompanyNews> News { get; set; }
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {

        }
    }
}


