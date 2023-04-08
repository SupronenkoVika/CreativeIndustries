using CreativeIndustries.API.Controllers;
using CreativeIndustries.API.Mappings;
using CreativeIndustries.DS.Contracts;
using CreativeIndustries.DS.DB.EF;
using CreativeIndustries.DS.EF;
using CreativeIndustries.DS.EF.Configuration;
using CreativeIndustries.DS.Entities;
using CreativeIndustries.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddSingleton<LocService>();
services.AddLocalization(options => options.ResourcesPath = "Resources");

services.AddControllersWithViews();
services.AddMvc()
    .AddViewLocalization()
    .AddDataAnnotationsLocalization(options =>
    {
        options.DataAnnotationLocalizerProvider = (type, factory) =>
        {
            var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
            return factory.Create("SharedResource", assemblyName.Name);
        };
    });

services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en"),
        new CultureInfo("ru"),
        new CultureInfo("be")
    };

    options.DefaultRequestCulture = new RequestCulture("en");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;

    options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
});


services.AddTransient<IMailService, MailService>();
services.AddTransient<ICompanyService, CompanyService>();

services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

var connectStr = builder.Configuration.GetConnectionString("DefaultConnection");
services.AddDbContext<AppDBContext>(opts => opts.UseSqlServer(connectStr));


services.AddIdentity<User, IdentityRole>(opts =>
    {
        opts.Password.RequiredLength = 6;
        opts.Password.RequireLowercase = true;
        opts.Password.RequireUppercase = true;
        opts.Password.RequireDigit = true;
        opts.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<AppDBContext>();

services.AddControllers().AddApplicationPart(typeof(AccountController).Assembly);

services.AddAutoMapper(typeof(CompanyProfile), typeof(NewsProfile), typeof(EventProfile));

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
