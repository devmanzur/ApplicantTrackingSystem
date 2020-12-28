using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;

namespace Hahn.ApplicatonProcess.December2020.Domain.Rules
{
    public class FamilyNameLengthMustBeAtLeast5Characters : IBusinessRule
    {
        private readonly string _familyName;

        public FamilyNameLengthMustBeAtLeast5Characters(string familyName)
        {
            _familyName = familyName;
        }

        public bool IsBroken() => _familyName.Length < 5;

        public string Message => "family name must be at least 5 characters";
    }
}