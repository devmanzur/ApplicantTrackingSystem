using System;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Domain.ValueObjects;
using Xunit;

namespace UnitTests.Domain.Entities.ApplicantTests
{
    public partial class ApplicantTest
    {
        [Fact]
        public void Applicant_create_is_successful_when_all_valid_data_is_provided()
        {
            //given
            Name name = ValidName();
            FamilyName familyName = ValidFamilyName();
            Address address = ValidAddress();
            Country countryOfOrigin = ValidCountry();
            EmailAddress emailAddress = ValidEmail();
            Age age = ValidAge();
            bool hired = false;
            Exception noExceptionThrown = null;

            //when
            var userRegistrationException = Record.Exception(() =>
                new Applicant(name, familyName, address, countryOfOrigin, emailAddress, age, hired));

            //then
            Assert.Equal(noExceptionThrown,userRegistrationException);
        }
    }
}