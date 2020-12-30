using System;
using System.Collections.Generic;
using FluentAssertions;
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
            string countryOfOrigin = ValidCountry();
            EmailAddress emailAddress = ValidEmail();
            Age age = ValidAge();
            bool hired = false;
            Exception noExceptionThrown = null;

            //act
            var userRegistrationException = Record.Exception(() =>
                new Applicant(name, familyName, address, countryOfOrigin, emailAddress, age, hired));

            //assert
            Assert.Equal(noExceptionThrown, userRegistrationException);
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public void Applicant_create_throws_business_rule_violation_exception_when_any_required_property_is_null(
            Name name,
            FamilyName familyName, Address address, string countryOfOrigin,
            EmailAddress emailAddress, Age age, bool hired)
        {

            //act
            Action action = () => new Applicant(name, familyName, address, countryOfOrigin, emailAddress, age, hired);

            //assert
            action.Should().Throw<BusinessRuleViolationException>();
        }

        public static IEnumerable<object[]> GetData =>
            new List<object[]>
            {
                new object[]
                    {null, ValidFamilyName(), ValidAddress(), ValidCountry(), ValidEmail(), ValidAge(), false},
                new object[]
                    {ValidName(), null, ValidAddress(), ValidCountry(), ValidEmail(), ValidAge(), true},
                new object[]
                    {ValidName(), ValidFamilyName(), null, ValidCountry(), ValidEmail(), ValidAge(), false},
                new object[]
                    {ValidName(), ValidFamilyName(), ValidAddress(), null, ValidEmail(), ValidAge(), true},
                new object[]
                    {ValidName(), ValidFamilyName(), ValidAddress(), ValidCountry(), null, ValidAge(), false},
                new object[]
                    {ValidName(), ValidFamilyName(), ValidAddress(), ValidCountry(), ValidEmail(), null, true},
                new object[]
                    {null, null, null, null, null, null, true},
            };
    }
}