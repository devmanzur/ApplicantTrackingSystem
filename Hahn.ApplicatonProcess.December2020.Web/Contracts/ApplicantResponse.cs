using Hahn.ApplicatonProcess.December2020.Domain.Entities;

namespace Hahn.ApplicatonProcess.December2020.Web.Contracts
{
    public class ApplicantResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Address { get; set; }
        public string CountryOfOrigin { get; set; }
        public string EmailAddress { get; set; }
        public int Age { get; set; }
        public bool Hired { get; set; }

        public static ApplicantResponse Map(Applicant applicant)
        {
            return new ApplicantResponse()
            {
                Id = applicant.Id,
                Name = applicant.Name.Value,
                FamilyName = applicant.FamilyName.Value,
                Address = applicant.Address.Value,
                CountryOfOrigin = applicant.CountryOfOrigin,
                EmailAddress = applicant.EmailAddress.Value,
                Age = applicant.Age.Value,
                Hired = applicant.Hired,
            };
        }
    }
}