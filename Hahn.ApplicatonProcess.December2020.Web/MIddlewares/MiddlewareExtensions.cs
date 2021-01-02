using Microsoft.AspNetCore.Builder;

namespace Hahn.ApplicatonProcess.December2020.Web.MIddlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestResponseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestResponseLoggingMiddleware>();
        }
    }
}