using Bogus;

namespace UnitTests.Domain.ValueObjects
{
    public class EmailAddressTests
    {
        private Faker _faker;

        public EmailAddressTests()
        {
            _faker = new Faker();
        }

        private string InvalidEmailAddress()
        {
            return _faker.Random.String(10, 30);
        }

        private string ValidEmailAddress()
        {
            return _faker.Internet.Email();
        }
    }
}