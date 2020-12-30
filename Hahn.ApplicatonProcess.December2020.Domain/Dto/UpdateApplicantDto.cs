namespace Hahn.ApplicatonProcess.December2020.Domain.Dto
{
    public class UpdateApplicantDto
    {
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Address { get; set; }
        public string CountryOfOrigin { get; set; }
        public string EmailAddress { get; set; }
        public int Age { get; set; }
        public bool Hired { get; set; }

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