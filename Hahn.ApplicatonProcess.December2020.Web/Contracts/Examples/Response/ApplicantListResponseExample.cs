using System.Collections.Generic;
using Swashbuckle.AspNetCore.Filters;

namespace Hahn.ApplicatonProcess.December2020.Web.Contracts.Examples.Response
{
    public class ApplicantListResponseExample : IExamplesProvider<List<ApplicantResponse>>
    {
        public List<ApplicantResponse> GetExamples()
        {
            return new List<ApplicantResponse>()
            {
                new ApplicantResponse()
                {
                    Id = 1,
                    Name = "Manzur",
                    FamilyName = "Alahi",
                    Address = "Dhaka, Bangladesh",
                    EmailAddress = "devmanzur@gmail.com",
                    CountryOfOrigin = "Bangladesh",
                    Age = 23,
                    Hired = false
                },
                new ApplicantResponse()
                {
                    Id = 2,
                    Name = "Simi",
                    FamilyName = "Ahmed",
                    Address = "Dhaka, Bangladesh",
                    EmailAddress = "simi@gmail.com",
                    CountryOfOrigin = "Bangladesh",
                    Age = 21,
                    Hired = false
                }
            };
        }
    }
}