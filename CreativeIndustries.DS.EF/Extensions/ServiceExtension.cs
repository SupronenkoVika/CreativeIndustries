using CreativeIndustries.DS.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace CreativeIndustries.DS.EF.Extensions
{
    public static class ServiceExtension
    {
        public static void AppServicesExtension(this IServiceCollection services)
        {
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IMailService, MailService>();
        }
    }
}
