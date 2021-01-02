using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Hahn.ApplicatonProcess.December2020.Web.Extensions
{
    public static class SwaggerSetupExtension
    {
        public static void SetupSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "APPLICANT TRACKING SYSTEM API",
                    Description = "This is the API for managing applicants",
                    Contact = new OpenApiContact
                    {
                        Name = "Manzur Alahi",
                        Email = "devmanzur@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/devmanzur")
                    }
                });

                c.ExampleFilters();
                
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddSwaggerExamplesFromAssemblyOf<Startup>();
        }
    }
}