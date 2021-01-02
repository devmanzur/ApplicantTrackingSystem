using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Domain.Dto;
using Hahn.ApplicatonProcess.December2020.Domain.Exceptions;

namespace Hahn.ApplicatonProcess.December2020.Domain.Services
{
    public partial class ApplicantService
    {
        private async Task ValidateApplicantDtoAsync(ApplicantDto dto)
        {
            var modelValidator = new ApplicantDtoValidator();
            var validation = await modelValidator.ValidateAsync(dto);
            if (!validation.IsValid)
            {
                throw new ApplicantPropertyValidationException(
                    validation.Errors.ToDictionary(x => x.PropertyName, x => x.ErrorMessage));
            }

            var fetchCountryData = await _countryDataProvider.ValidateCountry(dto.CountryOfOrigin);
            if (fetchCountryData.IsFailure)
            {
                throw new ApplicantPropertyValidationException(new Dictionary<string, string>()
                {
                    {nameof(ApplicantDto.CountryOfOrigin), $"country {dto.CountryOfOrigin} is not valid!"}
                });
            }
        }
    }
}