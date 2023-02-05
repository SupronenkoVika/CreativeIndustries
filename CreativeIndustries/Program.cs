using CreativeIndustries.API.Controllers;
using CreativeIndustries.DS.DB.EF;
using CreativeIndustries.DS.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CompanyDBContext>(opts => opts.UseSqlServer(connectStr));
builder.Services.AddDbContext<AppUserDBContext>(opts => opts.UseSqlServer(connectStr));

builder.Services.AddIdentity<User, IdentityRole>(opts =>
    {
        opts.Password.RequiredLength = 6;
        opts.Password.RequireLowercase = true;
        opts.Password.RequireUppercase = true;
        opts.Password.RequireDigit = true;
        opts.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<AppUserDBContext>();

builder.Services.AddControllers().AddApplicationPart(typeof(AccountController).Assembly); // How to add all solution controllers?


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
