using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;
using Hahn.ApplicatonProcess.December2020.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.ApplicatonProcess.December2020.Domain.Extensions
{
    public static class DependencyExtensions
    {
        public static void SetupDomainDependencies(this IServiceCollection services)
        {
            services.AddScoped<IApplicantService, ApplicantService>();
        }
    }
}