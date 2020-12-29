using Hahn.ApplicatonProcess.December2020.Data.Data;
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
        }
    }
}