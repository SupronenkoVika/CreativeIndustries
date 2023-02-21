using CreativeIndustries.API.Controllers;
using CreativeIndustries.DS.Contracts;
using CreativeIndustries.DS.DB.EF;
using CreativeIndustries.DS.EF;
using CreativeIndustries.DS.EF.Configuration;
using CreativeIndustries.DS.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddLocalization(options => options.ResourcesPath = "Resources");
services.AddControllersWithViews()
    .AddDataAnnotationsLocalization()
    .AddViewLocalization();
services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en"),
        new CultureInfo("ru")
    };

    options.DefaultRequestCulture = new RequestCulture("en");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

//services.Configure<MailSettings>(builder.Configuration.GetSection(nameof(MailSettings)));
services.AddTransient<IMailService, MailService>();
services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

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

app.UseRequestLocalization();

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
