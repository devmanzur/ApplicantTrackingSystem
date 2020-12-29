using Bogus;
using Hahn.ApplicatonProcess.December2020.Domain.ValueObjects;

namespace UnitTests.Domain.Entities.ApplicantTests
{
    public partial class ApplicantTest
    {
        private static readonly Faker _faker = new Faker();
        

        private static Name ValidName()
        {
            return new Name(_faker.Name.FullName());
        }

        private static FamilyName ValidFamilyName()
        {
            return new FamilyName(_faker.Name.FullName());
        }

        private static Address ValidAddress()
        {
            return new Address(_faker.Address.FullAddress());
        }

        private static string ValidCountry()
        {
            return _faker.Random.String(3);
        }

        private static EmailAddress ValidEmail()
        {
            return new EmailAddress(_faker.Internet.Email());
        }

        private static Age ValidAge()
        {
            return new Age(_faker.Random.Int(20,60));
        }

    }
}