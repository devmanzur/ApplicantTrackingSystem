using Bogus;
using Hahn.ApplicatonProcess.December2020.Domain.ValueObjects;

namespace UnitTests.Domain.Entities.ApplicantTests
{
    public partial class ApplicantTest
    {
        private readonly Faker _faker;

        public ApplicantTest()
        {
            _faker = new Faker();
        }

        private Name ValidName()
        {
            return new Name(_faker.Name.FullName());
        }

        private FamilyName ValidFamilyName()
        {
            return new FamilyName(_faker.Name.FullName());
        }

        private Address ValidAddress()
        {
            return new Address(_faker.Address.FullAddress());
        }

        private Country ValidCountry()
        {
            return new Country(_faker.Random.String(3), _faker.Random.String(2), _faker.Random.String(3));
        }

        private EmailAddress ValidEmail()
        {
            return new EmailAddress(_faker.Internet.Email());
        }

        private Age ValidAge()
        {
            return new Age(_faker.Random.Int(20,60));
        }

    }
}