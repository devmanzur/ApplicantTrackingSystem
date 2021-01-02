using System.Text.RegularExpressions;
using FluentValidation;

namespace Hahn.ApplicatonProcess.December2020.Domain.Dto
{
    public class ApplicantDto
    {
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Address { get; set; }
        public string CountryOfOrigin { get; set; }
        public string EmailAddress { get; set; }
        public int Age { get; set; }
        public bool Hired { get; set; }
    }

    public class ApplicantDtoValidator : AbstractValidator<ApplicantDto>
    {
        public ApplicantDtoValidator()
        {
            RuleFor(x => x.Name).Must(AtLeast5Characters)
                .WithMessage("name must be at least 5 characters");
            RuleFor(x => x.FamilyName).Must(AtLeast5Characters)
                .WithMessage("family name must be at least 5 characters");
            RuleFor(x => x.Address).Must(AtLeast10Characters)
                .WithMessage("address must be at least 10 characters");
            RuleFor(x => x.CountryOfOrigin).Must(ValidString)
                .WithMessage("invalid country");
            RuleFor(x => x.EmailAddress).Must(ValidEmail)
                .WithMessage("invalid email address");
            RuleFor(x => x.Age).NotNull().Must(ValidAge)
                .WithMessage("age must be between 20 and 60");
        }

        private bool ValidString(string arg)
        {
            return !string.IsNullOrEmpty(arg);
        }

        private bool ValidAge(int age)
        {
            return age >= 20 && age <= 60;
        }

        private bool ValidEmail(string arg)
        {
            if (string.IsNullOrEmpty(arg)) return false;
            var pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" +
                          @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" +
                          @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(arg);
        }

        private bool AtLeast5Characters(string arg)
        {
            return !string.IsNullOrEmpty(arg) && arg.Length >= 5;
        }

        private bool AtLeast10Characters(string arg)
        {
            return !string.IsNullOrEmpty(arg) && arg.Length >= 10;
        }
    }
}