namespace Hahn.ApplicatonProcess.December2020.Domain.Contract
{
    public class UpdateApplicantDto
    {
        public string Name { get; set; }
        private string FamilyName { get; set; }
        private string Address { get; set; }
        private string CountryOfOrigin { get; set; }
        private string EmailAddress { get; set; }
        private int Age { get; set; }
        private bool Hired { get; set; }

        public UpdateApplicantDto(string name, string familyName, string address,
            string countryOfOrigin,
            string emailAddress, int age, bool hired)
        {
            Name = name;
            FamilyName = familyName;
            Address = address;
            CountryOfOrigin = countryOfOrigin;
            EmailAddress = emailAddress;
            Age = age;
            Hired = hired;
        }
    }
}