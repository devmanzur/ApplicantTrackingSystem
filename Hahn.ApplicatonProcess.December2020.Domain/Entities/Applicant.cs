using Hahn.ApplicatonProcess.December2020.Domain.Exceptions;
using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;
using Hahn.ApplicatonProcess.December2020.Domain.Rules;
using Hahn.ApplicatonProcess.December2020.Domain.ValueObjects;

namespace Hahn.ApplicatonProcess.December2020.Domain.Entities
{
    public class Applicant
    {
        public Applicant(PersonName name, FamilyName familyName, Address address, Country countryOfOrigin,
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
        public PersonName Name { get; private set; }
        public FamilyName FamilyName { get; private set; }
        public Address Address { get; private set; }
        public Country CountryOfOrigin { get; private set; }
        public EmailAddress EmailAddress { get; private set; }
        public Age Age { get; private set; }
        public bool Hired { get; private set; }

        public void Set(PersonName name)
        {
            Name = name;
        }

        public void Set(FamilyName familyName)
        {
            FamilyName = familyName;
        }

        public void Set(Address address)
        {
            Address = address;
        }

        public void Set(Country country)
        {
            CountryOfOrigin = country;
        }

        public void Set(EmailAddress emailAddress)
        {
            EmailAddress = emailAddress;
        }

        public void Set(Age age)
        {
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