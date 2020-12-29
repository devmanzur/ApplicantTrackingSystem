using System;
using Bogus;
using Hahn.ApplicatonProcess.December2020.Domain.Exceptions;
using Hahn.ApplicatonProcess.December2020.Domain.Rules;
using Hahn.ApplicatonProcess.December2020.Domain.ValueObjects;
using Xunit;

namespace UnitTests.Domain.ValueObjects
{
    public class FamilyNameTests
    {
        private Faker _faker;

        public FamilyNameTests()
        {
            _faker = new Faker();
        }

        private string InvalidFamilyName()
        {
            return _faker.Random.String(1, 4);
        }

        private string ValidFamilyName()
        {
            return _faker.Random.String(5);
        }
        
        [Fact]
        public void FamilyName_initialization_throws_business_rule_violation_exception_when_family_name_length_is_less_than_5()
        {
            //arrange
            string invalidFamilyName = InvalidFamilyName();
            var  expectedBusinessRuleViolationException = new BusinessRuleViolationException(new FamilyNameLengthMustBeAtLeast5Characters(invalidFamilyName));

            //act
            var actualException = Record.Exception(()=> new FamilyName(invalidFamilyName));

            //assert
            Assert.IsType<BusinessRuleViolationException>(actualException);
            Assert.Equal(expectedBusinessRuleViolationException.Message,actualException.Message);
        }
        
        [Fact]
        public void FamilyName_initialization_throws_business_rule_violation_exception_when_family_name_is_null()
        {
            //arrange
            string invalidFamilyName = null;
            var  expectedBusinessRuleViolationException = new BusinessRuleViolationException(new FamilyNameLengthMustBeAtLeast5Characters(invalidFamilyName));

            //act
            var actualException = Record.Exception(()=> new FamilyName(invalidFamilyName));

            //assert
            Assert.IsType<BusinessRuleViolationException>(actualException);
            Assert.Equal(expectedBusinessRuleViolationException.Message,actualException.Message);
        }

        [Fact]
        public void FamilyName_initialization_is_successful_when_family_name_is_at_least_5_characters()
        {
            //arrange
            string validFamilyName = ValidFamilyName();
            Exception noExceptionThrown = null;

            //act
            var actualException = Record.Exception(()=> new FamilyName(validFamilyName));

            //assert
            Assert.Equal(noExceptionThrown,actualException);
        }
    }
}