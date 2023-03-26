using CreativeIndustries.DS.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CreativeIndustries.DS.DB.EF
{
    public class AppUserDBContext : IdentityDbContext<User>
    {
        //public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }

        public AppUserDBContext(DbContextOptions<AppUserDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    string adminRole = "admin";
        //    string userRole = "user";

        //    string adminEmail = "viktoryia.education@gmail.com";
        //    string adminPassword = "";
        //}
    }

    //public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    //{
    //    public void Configure(EntityTypeBuilder<User> builder)
    //    {
    //        builder.Property(u => u.FirstName).HasMaxLength(255);
    //        builder.Property(u => u.LastName).HasMaxLength(255);
    //    }
    //}
}


