using System;
using Hahn.ApplicatonProcess.December2020.Data.Extensions;
using Hahn.ApplicatonProcess.December2020.Domain.Extensions;
using Hahn.ApplicatonProcess.December2020.Web.MIddlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Hahn.ApplicatonProcess.December2020.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddRouting(options => options.LowercaseUrls = true);
            services.SetupDomainDependencies();
            services.SetupDataDependencies();
            SetupSwagger(services);
        }
        
        private static void SetupSwagger(IServiceCollection services)
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
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseSwagger();
            app.UseSwaggerUI(x => { x.SwaggerEndpoint("/swagger/v1/swagger.json", "APPLICANT: API"); });

            app.UseRequestResponseLogging();

            app.UseExceptionFormatting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}