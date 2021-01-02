using Hahn.ApplicatonProcess.December2020.Domain.Dto;
using Swashbuckle.AspNetCore.Filters;

namespace Hahn.ApplicatonProcess.December2020.Web.Contracts.Examples.Requests
{
    public class ApplicantRequestExample : IExamplesProvider<ApplicantDto>
    {
        public ApplicantDto GetExamples()
        {
            return new ApplicantDto()
            {
                Name = "Manzur",
                FamilyName = "Alahi",
                Address = "Dhaka, Bangladesh",
                CountryOfOrigin = "Bangladesh",
                Age = 23,
                Hired = false
            };
        }
    }
}