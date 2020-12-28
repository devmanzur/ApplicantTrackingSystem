using Hahn.ApplicatonProcess.December2020.Domain.Rules;

namespace Hahn.ApplicatonProcess.December2020.Domain.ValueObjects
{
    public class FamilyName : ValueObject
    {
        public string Value { get; private set; }

        public FamilyName(string value)
        {
            CheckRule(new FamilyNameLengthMustBeAtLeast5Characters(value));
            Value = value;
        }
    }
}