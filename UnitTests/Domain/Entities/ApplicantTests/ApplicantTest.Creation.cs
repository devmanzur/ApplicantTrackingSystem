using System;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Domain.Exceptions;
using Hahn.ApplicatonProcess.December2020.Domain.Rules;
using Hahn.ApplicatonProcess.December2020.Domain.ValueObjects;
using Xunit;

namespace UnitTests.Domain.Entities.ApplicantTests
{
    public partial class ApplicantTest
    {
        [Fact]
        public void Applicant_create_is_successful_when_all_valid_data_is_provided()
        {
            //arrange
            Name name = ValidName();
            FamilyName familyName = ValidFamilyName();
            Address address = ValidAddress();
            Country countryOfOrigin = ValidCountry();
            EmailAddress emailAddress = ValidEmail();
            Age age = ValidAge();
            bool hired = false;
            Exception noExceptionThrown = null;

            //act
            var userRegistrationException = Record.Exception(() =>
                new Applicant(name, familyName, address, countryOfOrigin, emailAddress, age, hired));

            //assert
            Assert.Equal(noExceptionThrown,userRegistrationException);
        }
        
        [Fact]
        public void Applicant_create_throws_business_rule_violation_exception_when_name_is_null()
        {
            //arrange
            Name name = null;
            FamilyName familyName = ValidFamilyName();
            Address address = ValidAddress();
            Country countryOfOrigin = ValidCountry();
            EmailAddress emailAddress = ValidEmail();
            Age age = ValidAge();
            bool hired = false;
            var  expectedBusinessRuleViolationException = new BusinessRuleViolationException(new PropertyMustNotBeNull(name,nameof(Applicant.Name)));

            //act
            var userRegistrationException = Record.Exception(() =>
                new Applicant(name, familyName, address, countryOfOrigin, emailAddress, age, hired));

            //assert
            Assert.IsType<BusinessRuleViolationException>(userRegistrationException);
            Assert.Equal(expectedBusinessRuleViolationException.Message,userRegistrationException.Message);
        }
        
        
    }
}