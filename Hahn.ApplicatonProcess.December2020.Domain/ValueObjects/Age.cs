using Hahn.ApplicatonProcess.December2020.Domain.Rules;

namespace Hahn.ApplicatonProcess.December2020.Domain.ValueObjects
{
    public class Age : ValueObject
    {
        public int Value { get; private set; }

        public Age(int value)
        {
            CheckRule(new AgeMustBeBetween20And60(value));
            Value = value;
        }
        
        
    }
}