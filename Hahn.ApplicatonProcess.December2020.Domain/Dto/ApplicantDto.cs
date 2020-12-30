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
            RuleFor(x => x.Name).NotNull().NotEmpty().Must(AtLeast5Characters)
                .WithMessage("name must be at least 5 characters");
            RuleFor(x => x.FamilyName).NotNull().NotEmpty().Must(AtLeast5Characters)
                .WithMessage("family name must be at least 5 characters");
            RuleFor(x => x.Address).NotNull().NotEmpty().Must(AtLeast10Characters)
                .WithMessage("address must be at least 10 characters");
            RuleFor(x => x.CountryOfOrigin).NotNull().NotEmpty()
                .WithMessage("invalid country");
            RuleFor(x => x.EmailAddress).NotNull().NotEmpty().Must(ValidEmail)
                .WithMessage("invalid email address");
            RuleFor(x => x.Age).NotNull().NotEmpty().Must(ValidAge)
                .WithMessage("age must be between 20 and 60");
        }

        private bool ValidAge(int age)
        {
            return age >= 20 && age <= 60;
        }

        private bool ValidEmail(string arg)
        {
            var pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" +
                          @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" +
                          @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(arg);
        }

        private bool AtLeast5Characters(string arg)
        {
            return arg != null && arg.Length >= 5;
        }

        private bool AtLeast10Characters(string arg)
        {
            return arg != null && arg.Length >= 10;
        }
    }
}