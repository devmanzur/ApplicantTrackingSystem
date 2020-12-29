using Bogus;
using Hahn.ApplicatonProcess.December2020.Domain.Exceptions;
using Hahn.ApplicatonProcess.December2020.Domain.Rules;
using Hahn.ApplicatonProcess.December2020.Domain.ValueObjects;
using Xunit;

namespace UnitTests.Domain.ValueObjects
{
    public class NameTests
    {
        private Faker _faker;

        public NameTests()
        {
            _faker = new Faker();
        }

        private string InvalidName()
        {
            return _faker.Random.String(1, 4);
        }

        //Name_create_throws_business_rule_violation_exception_when_name_length_is_less_than_5
        
        [Fact]
        public void Name_throws_business_rule_violation_exception_when_name_length_is_less_than_5()
        {
            //arrange
            var invalidName = InvalidName();
            var  expectedBusinessRuleViolationException = new BusinessRuleViolationException(new NameLengthMustBeAtLeast5Characters(invalidName));

            //act
            var userRegistrationException = Record.Exception(()=> new Name(invalidName));

            //assert
            Assert.IsType<BusinessRuleViolationException>(userRegistrationException);
            Assert.Equal(expectedBusinessRuleViolationException.Message,userRegistrationException.Message);
        }
        
        
        
    }
}