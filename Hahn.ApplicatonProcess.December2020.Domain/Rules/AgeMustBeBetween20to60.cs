using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;

namespace Hahn.ApplicatonProcess.December2020.Domain.Rules
{
    public class AgeMustBeBetween20To60 : IBusinessRule
    {
        private readonly int _age;

        public AgeMustBeBetween20To60(int age)
        {
            _age = age;
        }

        public bool IsBroken()
        {
            return _age < 20 || _age > 60;
        }

        public string Message => "age must be between 20 and 60";
    }
}