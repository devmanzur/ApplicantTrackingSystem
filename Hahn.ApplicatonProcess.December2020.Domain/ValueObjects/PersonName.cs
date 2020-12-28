using Hahn.ApplicatonProcess.December2020.Domain.Rules;

namespace Hahn.ApplicatonProcess.December2020.Domain.ValueObjects
{
    public class PersonName : ValueObject
    {
        public string Value { get; private set; }

        public PersonName(string value)
        {
            CheckRule(new NameLengthMustBeAtLeast5Characters(value));
            Value = value;
        }
    }
}