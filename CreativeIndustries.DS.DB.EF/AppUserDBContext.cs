using CreativeIndustries.DS.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CreativeIndustries.DS.DB.EF
{
    public class AppUserDBContext : IdentityDbContext<User>
    {
        public AppUserDBContext(DbContextOptions<AppUserDBContext> options)
            : base(options)
        {
        }
    }
}


