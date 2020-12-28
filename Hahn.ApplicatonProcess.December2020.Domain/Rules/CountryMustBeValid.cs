using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;

namespace Hahn.ApplicatonProcess.December2020.Domain.Rules
{
    public class CountryMustBeValid : IBusinessRule
    {
        private readonly string _name;
        private readonly string _alpha2Code;
        private readonly string _alpha3Code;

        public CountryMustBeValid(string name, string alpha2Code, string alpha3Code)
        {
            _name = name;
            _alpha2Code = alpha2Code;
            _alpha3Code = alpha3Code;
        }

        public bool IsBroken()
        {
            if (_name == null || _alpha2Code == null || _alpha2Code.Length != 2 || _alpha3Code == null ||
                _alpha3Code.Length != 3)
            {
                return true;
            }

            return false;
        }

        public string Message => "country must be valid";
    }
}