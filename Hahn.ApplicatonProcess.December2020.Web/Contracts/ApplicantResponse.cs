using Hahn.ApplicatonProcess.December2020.Domain.Entities;

namespace Hahn.ApplicatonProcess.December2020.Web.Contracts
{
    public class ApplicantResponse
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string FamilyName { get; private set; }
        public string Address { get; private set; }
        public string CountryOfOrigin { get; private set; }
        public string EmailAddress { get; private set; }
        public int Age { get; private set; }
        public bool Hired { get; private set; }

        public static ApplicantResponse From(Applicant applicant)
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