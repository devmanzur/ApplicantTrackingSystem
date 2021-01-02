using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;

namespace Hahn.ApplicatonProcess.December2020.Domain.Rules
{
    public class AddressLengthMustBeAtLeast10Characters
        : IBusinessRule
    {
        private readonly string _address;

        public AddressLengthMustBeAtLeast10Characters(string address)
        {
            _address = address;
        }

        public bool IsBroken()
        {
            return _address == null || _address.Length < 10;
        }

        public string ErrorMessage => "address must be at least 10 characters";
        public string PropertyName  => "address";
    }
}