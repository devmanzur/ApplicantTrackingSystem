using System;
using Bogus;
using Hahn.ApplicatonProcess.December2020.Domain.Exceptions;
using Hahn.ApplicatonProcess.December2020.Domain.Rules;
using Hahn.ApplicatonProcess.December2020.Domain.ValueObjects;
using Xunit;

namespace UnitTests.Domain.Properties
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

        private string ValidName()
        {
            return _faker.Random.String(5);
        }
        
        [Fact]
        public void Name_initialization_throws_business_rule_violation_exception_when_name_length_is_less_than_5()
        {
            //arrange
            string invalidName = InvalidName();
            var  expectedBusinessRuleViolationException = new BusinessRuleViolationException(new NameLengthMustBeAtLeast5Characters(invalidName));

            //act
            var actualException = Record.Exception(()=> new Name(invalidName));

            //assert
            Assert.IsType<BusinessRuleViolationException>(actualException);
            Assert.Equal(expectedBusinessRuleViolationException.Message,actualException.Message);
        }
        
        [Fact]
        public void Name_initialization_throws_business_rule_violation_exception_when_name_is_null()
        {
            //arrange
            string invalidName = null;
            var  expectedBusinessRuleViolationException = new BusinessRuleViolationException(new NameLengthMustBeAtLeast5Characters(invalidName));

            //act
            var actualException = Record.Exception(()=> new Name(invalidName));

            //assert
            Assert.IsType<BusinessRuleViolationException>(actualException);
            Assert.Equal(expectedBusinessRuleViolationException.Message,actualException.Message);
        }

        [Fact]
        public void Name_initialization_is_successful_when_name_is_at_least_5_characters()
        {
            //arrange
            string validName = ValidName();
            Exception noExceptionThrown = null;

            //act
            var actualException = Record.Exception(()=> new Name(validName));

            //assert
            Assert.Equal(noExceptionThrown,actualException);
        }
    }
}