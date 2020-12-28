using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;

namespace Hahn.ApplicatonProcess.December2020.Domain.Rules
{
    public class NameLengthMustBeAtLeast5Characters : IBusinessRule
    {
        private readonly string _name;

        public NameLengthMustBeAtLeast5Characters(string name)
        {
            _name = name;
        }

        public bool IsBroken(){
            return _name == null || _name.Length < 5;
        }

        public string Message => "name must be at least 5 characters";
    }
}