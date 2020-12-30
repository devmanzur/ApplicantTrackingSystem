using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using FluentValidation;
using Hahn.ApplicatonProcess.December2020.Domain.Dto;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;

namespace Hahn.ApplicatonProcess.December2020.Domain.Services
{
    public partial class ApplicantService
    {
        private async Task ValidateCreateRequestAsync(CreateApplicantDto dto)
        {
            var modelValidator = new CreateApplicantDtoValidator();
            var validation = await modelValidator.ValidateAsync(dto);
            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }

            var fetchCountryData = await _countryDataProvider.GetCountry(dto.CountryOfOrigin);
            if (fetchCountryData.IsFailure)
            {
                throw new ValidationException($"country {dto.CountryOfOrigin} is not valid!");
            }
        }
    }
}