using Hahn.ApplicatonProcess.December2020.Data.Data;
using Hahn.ApplicatonProcess.December2020.Data.Logs;
using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.ApplicatonProcess.December2020.Data.Extensions
{
    public static class DependencyExtensions
    {
        public static void SetupDataDependencies(this IServiceCollection services)
        {
            services.AddDbContext<ApplicantDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: "Applicants"));
            services.AddScoped<IApplicantRepository, ApplicantRepository>();
            services.AddScoped<ICountryDataProvider, CountryDataProvider>();
            services.AddScoped<ILoggingBroker, LoggingBroker>();
        }
    }
}