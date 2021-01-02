using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hahn.ApplicatonProcess.December2020.Data.Data.Configuration
{
    public class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
    {
        public void Configure(EntityTypeBuilder<Applicant> builder)
        {
            builder.OwnsOne(x => x.Address);
            builder.OwnsOne(x => x.Name);
            builder.OwnsOne(x => x.FamilyName);
            builder.OwnsOne(x => x.EmailAddress);
            builder.OwnsOne(x => x.Age);
        }
    }
}