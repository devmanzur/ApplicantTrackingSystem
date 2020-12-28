using Bogus;
using Hahn.ApplicatonProcess.December2020.Domain.ValueObjects;

namespace UnitTests.Domain.ValueObjects
{
    public partial class ValueObjectTests
    {
        private Faker _faker;

        public ValueObjectTests()
        {
            _faker = new Faker();
        }
        private string InvalidString(int length)
        {
            return _faker.Random.String(1, length);
        }
    }
}