using Hahn.ApplicatonProcess.December2020.Domain.Exceptions;
using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;
using Hahn.ApplicatonProcess.December2020.Domain.Rules;
using Hahn.ApplicatonProcess.December2020.Domain.ValueObjects;

namespace Hahn.ApplicatonProcess.December2020.Domain.Entities
{
    public class Applicant
    {
        public Applicant(Name name, FamilyName familyName, Address address, Country countryOfOrigin,
            EmailAddress emailAddress, Age age, bool hired = false)
        {
            CheckRule(new PropertyMustNotBeNull(name, nameof(Name)));
            CheckRule(new PropertyMustNotBeNull(familyName, nameof(FamilyName)));
            CheckRule(new PropertyMustNotBeNull(address, nameof(Address)));
            CheckRule(new PropertyMustNotBeNull(countryOfOrigin, nameof(CountryOfOrigin)));
            CheckRule(new PropertyMustNotBeNull(emailAddress, nameof(EmailAddress)));
            CheckRule(new PropertyMustNotBeNull(age, nameof(Age)));

            Name = name;
            FamilyName = familyName;
            Address = address;
            CountryOfOrigin = countryOfOrigin;
            EmailAddress = emailAddress;
            Age = age;
            Hired = hired;
        }

        public int Id { get; protected set; }
        public Name Name { get; private set; }
        public FamilyName FamilyName { get; private set; }
        public Address Address { get; private set; }
        public Country CountryOfOrigin { get; private set; }
        public EmailAddress EmailAddress { get; private set; }
        public Age Age { get; private set; }
        public bool Hired { get; private set; }

        public void Set(Name name)
        {
            CheckRule(new PropertyMustNotBeNull(name, nameof(Name)));
            Name = name;
        }

        public void Set(FamilyName familyName)
        {
            CheckRule(new PropertyMustNotBeNull(familyName, nameof(FamilyName)));
            FamilyName = familyName;
        }

        public void Set(Address address)
        {
            CheckRule(new PropertyMustNotBeNull(address, nameof(Address)));
            Address = address;
        }

        public void Set(Country country)
        {
            CheckRule(new PropertyMustNotBeNull(country, nameof(CountryOfOrigin)));
            CountryOfOrigin = country;
        }

        public void Set(EmailAddress emailAddress)
        {
            CheckRule(new PropertyMustNotBeNull(emailAddress, nameof(EmailAddress)));
            EmailAddress = emailAddress;
        }

        public void Set(Age age)
        {
            CheckRule(new PropertyMustNotBeNull(age, nameof(Age)));
            Age = age;
        }

        public void Set(bool isHired)
        {
            Hired = isHired;
        }

        private void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken())
            {
                throw new BusinessRuleViolationException(rule);
            }
        }
    }
}