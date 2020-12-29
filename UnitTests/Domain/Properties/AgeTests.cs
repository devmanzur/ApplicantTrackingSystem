using System;
using Bogus;
using Hahn.ApplicatonProcess.December2020.Domain.Exceptions;
using Hahn.ApplicatonProcess.December2020.Domain.Rules;
using Hahn.ApplicatonProcess.December2020.Domain.ValueObjects;
using Xunit;

namespace UnitTests.Domain.Properties
{
    public class AgeTests
    {
        private Faker _faker;

        private int ValidAge()
        {
            return _faker.Random.Int(20,60);
        }
        
        private int InvalidAge()
        {
            return _faker.Random.Int(61,300);
        }
        
        public AgeTests()
        {
            _faker = new Faker();
        }
        
        [Fact]
        public void Age_initialization_throws_business_rule_violation_exception_when_age_is_not_between_20_to_60()
        {
            //arrange
            var invalidAge = InvalidAge();
            var  expectedBusinessRuleViolationException = new BusinessRuleViolationException(new AgeMustBeBetween20To60(invalidAge));

            //act
            var actualException = Record.Exception(()=> new Age(invalidAge));

            //assert
            Assert.IsType<BusinessRuleViolationException>(actualException);
            Assert.Equal(expectedBusinessRuleViolationException.Message,actualException.Message);
        }
        
        [Fact]
        public void Age_initialization_is_successful_when_age_is_between_20_to_60()
        {
            //arrange
            var validAge = ValidAge();
            Exception noExceptionThrown = null;

            //act
            var actualException = Record.Exception(()=> new Age(validAge));

            
            //assert
            Assert.Equal(noExceptionThrown,actualException);
        }
    }
}