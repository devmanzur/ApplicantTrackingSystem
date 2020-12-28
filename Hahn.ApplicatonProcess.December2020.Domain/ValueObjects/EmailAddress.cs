using Hahn.ApplicatonProcess.December2020.Domain.Rules;

namespace Hahn.ApplicatonProcess.December2020.Domain.ValueObjects
{
    public class EmailAddress : ValueObject
    {
        public string Value { get; private set; }
        public EmailAddress(string value)
        {
            CheckRule(new EmailMustBeValid(value));
            Value = value;
        }
    }
}