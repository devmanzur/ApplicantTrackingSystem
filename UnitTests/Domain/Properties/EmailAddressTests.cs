using System;
using Bogus;
using Hahn.ApplicatonProcess.December2020.Domain.Exceptions;
using Hahn.ApplicatonProcess.December2020.Domain.Rules;
using Hahn.ApplicatonProcess.December2020.Domain.ValueObjects;
using Xunit;

namespace UnitTests.Domain.Properties
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
        
        [Fact]
        public void EmailAddress_initialization_throws_business_rule_violation_exception_when_email_address_is_invalid()
        {
            //arrange
            string invalidEmail = InvalidEmailAddress();
            var  expectedBusinessRuleViolationException = new BusinessRuleViolationException(new EmailMustBeValid(invalidEmail));

            //act
            var actualException = Record.Exception(()=> new EmailAddress(invalidEmail));

            //assert
            Assert.IsType<BusinessRuleViolationException>(actualException);
            Assert.Equal(expectedBusinessRuleViolationException.Message,actualException.Message);
        }
        
        [Fact]
        public void EmailAddress_initialization_throws_business_rule_violation_exception_when_email_address_is_null()
        {
            //arrange
            string invalidEmail = null;
            var  expectedBusinessRuleViolationException = new BusinessRuleViolationException(new EmailMustBeValid(invalidEmail));

            //act
            var actualException = Record.Exception(()=> new EmailAddress(invalidEmail));

            //assert
            Assert.IsType<BusinessRuleViolationException>(actualException);
            Assert.Equal(expectedBusinessRuleViolationException.Message,actualException.Message);
        }
        
        [Fact]
        public void EmailAddress_initialization_is_successful_when_email_address_is_valid()
        {
            //arrange
            string validEmail = ValidEmailAddress();
            Exception noExceptionThrown = null;

            //act
            var actualException = Record.Exception(()=> new EmailAddress(validEmail));

            //assert
            Assert.Equal(noExceptionThrown,actualException);
        }
    }
}