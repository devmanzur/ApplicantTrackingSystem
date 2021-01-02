using System.Reflection;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.December2020.Data.Data
{
    public class ApplicantDbContext : DbContext
    {
        public DbSet<Applicant> Applicants { get; set; }

        public ApplicantDbContext(DbContextOptions<ApplicantDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}