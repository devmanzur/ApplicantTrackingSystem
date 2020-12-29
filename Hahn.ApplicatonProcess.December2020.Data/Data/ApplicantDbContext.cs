using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.December2020.Data.Data
{
    public class ApplicantDbContext : DbContext
    {
        public DbSet<Applicant> Applicants;
        public ApplicantDbContext(DbContextOptions<ApplicantDbContext> options) : base(options)
        {
            
        }
    }
}