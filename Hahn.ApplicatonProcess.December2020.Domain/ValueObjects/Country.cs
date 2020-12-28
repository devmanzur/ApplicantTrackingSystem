using Hahn.ApplicatonProcess.December2020.Domain.Rules;

namespace Hahn.ApplicatonProcess.December2020.Domain.ValueObjects
{
    public class Country : ValueObject
    {
        public Country(string name, string alpha2Code, string alpha3Code)
        {
            CheckRule(new CountryMustBeValid(name,alpha2Code,alpha3Code));
            Name = name;
            Alpha2Code = alpha2Code;
            Alpha3Code = alpha3Code;
        }

        public string Name { get; private set; }
        public string Alpha2Code { get;private set; }
        public string Alpha3Code { get;private set; }
    }
}