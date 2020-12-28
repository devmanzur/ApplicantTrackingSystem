using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Domain.Exceptions;
using Hahn.ApplicatonProcess.December2020.Domain.Rules;
using Hahn.ApplicatonProcess.December2020.Domain.ValueObjects;
using Xunit;

namespace UnitTests.Domain.ValueObjects
{
    public partial class ValueObjectTests
    {
            
        [Fact]
        public void Name_create_throws_business_rule_violation_exception_when_name_length_is_less_than_5()
        {
            //arrange
            var invalidName = InvalidString(4);
            var  expectedBusinessRuleViolationException = new BusinessRuleViolationException(new NameLengthMustBeAtLeast5Characters(invalidName));

            //act
            var userRegistrationException = Record.Exception(()=> new Name(invalidName));

            //assert
            Assert.IsType<BusinessRuleViolationException>(userRegistrationException);
            Assert.Equal(expectedBusinessRuleViolationException.Message,userRegistrationException.Message);
        }
        
    }
}