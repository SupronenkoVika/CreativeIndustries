using CreativeIndustries.API.Controllers;
using CreativeIndustries.DS.Contracts;
using CreativeIndustries.DS.DB.EF;
using CreativeIndustries.DS.EF;
using CreativeIndustries.DS.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddControllersWithViews();
//services.Configure<MailSettings>(builder.Configuration.GetSection(nameof(MailSettings)));
services.AddTransient<IMailService, MailService>();
builder.Configuration.GetSection("MailData");

var connectStr = builder.Configuration.GetConnectionString("DefaultConnection");
services.AddDbContext<CompanyDBContext>(opts => opts.UseSqlServer(connectStr));
services.AddDbContext<AppUserDBContext>(opts => opts.UseSqlServer(connectStr));

services.AddIdentity<User, IdentityRole>(opts =>
    {
        opts.Password.RequiredLength = 6;
        opts.Password.RequireLowercase = true;
        opts.Password.RequireUppercase = true;
        opts.Password.RequireDigit = true;
        opts.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<AppUserDBContext>();

services.AddControllers().AddApplicationPart(typeof(AccountController).Assembly); // How to add all solution controllers?



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
