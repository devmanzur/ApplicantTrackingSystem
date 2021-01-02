using Swashbuckle.AspNetCore.Filters;

namespace Hahn.ApplicatonProcess.December2020.Web.Contracts.Examples.Response
{
    public class ApplicantResponseExample : IExamplesProvider<Envelope<ApplicantResponse>>
    {
        public Envelope<ApplicantResponse> GetExamples()
        {
            return Envelope.Ok(new ApplicantResponse()
            {
                Id = 1,
                Name = "Manzur",
                FamilyName = "Alahi",
                Address = "Dhaka, Bangladesh",
                CountryOfOrigin = "Bangladesh",
                Age = 23,
                Hired = false
            });
        }
    }
}