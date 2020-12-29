using System;
using Bogus;
using Hahn.ApplicatonProcess.December2020.Domain.Exceptions;
using Hahn.ApplicatonProcess.December2020.Domain.Rules;
using Hahn.ApplicatonProcess.December2020.Domain.ValueObjects;
using Xunit;

namespace UnitTests.Domain.ValueObjects
{
    public class AddressTests
    {
        private Faker _faker;

        public AddressTests()
        {
            _faker = new Faker();
        }

        private string InvalidAddress()
        {
            return _faker.Random.String(1, 9);
        }

        private string ValidAddress()
        {
            return _faker.Random.String(10);
        }
        
        [Fact]
        public void Address_initialization_throws_business_rule_violation_exception_when_address_length_is_less_than_10()
        {
            //arrange
            string invalidAddress = InvalidAddress();
            var  expectedBusinessRuleViolationException = new BusinessRuleViolationException(new AddressLengthMustBeAtLeast10Characters(invalidAddress));

            //act
            var actualException = Record.Exception(()=> new Address(invalidAddress));

            //assert
            Assert.IsType<BusinessRuleViolationException>(actualException);
            Assert.Equal(expectedBusinessRuleViolationException.Message,actualException.Message);
        }
        
        [Fact]
        public void Address_initialization_throws_business_rule_violation_exception_when_address_is_null()
        {
            //arrange
            string invalidAddress = null;
            var  expectedBusinessRuleViolationException = new BusinessRuleViolationException(new AddressLengthMustBeAtLeast10Characters(invalidAddress));

            //act
            var actualException = Record.Exception(()=> new Address(invalidAddress));

            //assert
            Assert.IsType<BusinessRuleViolationException>(actualException);
            Assert.Equal(expectedBusinessRuleViolationException.Message,actualException.Message);
        }

        [Fact]
        public void Address_initialization_is_successful_when_address_is_at_least_10_characters()
        {
            //arrange
            string validAddress = ValidAddress();
            Exception noExceptionThrown = null;

            //act
            var actualException = Record.Exception(()=> new Address(validAddress));

            //assert
            Assert.Equal(noExceptionThrown,actualException);
        }
    }
}