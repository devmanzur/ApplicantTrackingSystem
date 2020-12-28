using Hahn.ApplicatonProcess.December2020.Domain.Rules;

namespace Hahn.ApplicatonProcess.December2020.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string Value { get; private set; }

        public Address(string value)
        {
            CheckRule(new AddressLengthMustBeAtLeast10Characters(value));
            Value = value;
        }
    }
}