using System.Text.RegularExpressions;
using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;

namespace Hahn.ApplicatonProcess.December2020.Domain.Rules
{
    public class EmailMustBeValid : IBusinessRule
    {
        private readonly string _value;

        public EmailMustBeValid(string value)
        {
            _value = value;
        }

        public bool IsBroken()
        {
            if (_value == null) return true;
            
            var pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" +
                          @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" +
                          @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return !regex.IsMatch(_value);
        }

        public string ErrorMessage => "email must be valid";
        public string PropertyName => "email";
    }
}