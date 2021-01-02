using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;

namespace Hahn.ApplicatonProcess.December2020.Domain.Rules
{
    public class PropertyMustNotBeNull : IBusinessRule
    {
        private readonly object _value;
        private readonly string _name;

        public PropertyMustNotBeNull(object value, string name)
        {
            _value = value;
            _name = name;
        }

        public bool IsBroken() => _value == null;

        public string ErrorMessage => $"{_name} must not be null";
        public string PropertyName => _name?.ToLower();
    }
}