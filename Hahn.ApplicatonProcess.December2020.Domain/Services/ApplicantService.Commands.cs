using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Hahn.ApplicatonProcess.December2020.Domain.Dto;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;
using Hahn.ApplicatonProcess.December2020.Domain.ValueObjects;

namespace Hahn.ApplicatonProcess.December2020.Domain.Services
{
    public partial class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly ILoggingBroker _loggingBroker;
        private readonly ICountryDataProvider _countryDataProvider;

        public ApplicantService(IApplicantRepository applicantRepository, ILoggingBroker loggingBroker,
            ICountryDataProvider countryDataProvider)
        {
            _applicantRepository = applicantRepository;
            _loggingBroker = loggingBroker;
            _countryDataProvider = countryDataProvider;
        }

        public Task<Result<Applicant>> RegisterApplicant(ApplicantDto dto) =>
            TryCatch(async () =>
            {
                await ValidateApplicantDtoAsync(dto);

                var applicant = new Applicant(new Name(dto.Name), new FamilyName(dto.FamilyName),
                    new Address(dto.Address), dto.CountryOfOrigin, new EmailAddress(dto.EmailAddress),
                    new Age(dto.Age), dto.Hired);
                await _applicantRepository.Create(applicant);
                return Result.Success(applicant);
            });


        public Task<Result<Applicant>> ModifyApplicant(int applicantId, ApplicantDto update) =>
            TryCatch(async () =>
            {
                await ValidateApplicantDtoAsync(update);

                var applicant = await _applicantRepository.FindById(applicantId);
                if (applicant == null)
                {
                    return Result.Failure<Applicant>($"applicant {applicantId} not found!");
                }

                Apply(applicant, update);

                await _applicantRepository.Update(applicant);
                return Result.Success(applicant);
            });

        private void Apply(Applicant applicant, ApplicantDto update)
        {
            applicant.Set(new Name(update.Name));
            applicant.Set(new FamilyName(update.FamilyName));
            applicant.Set(new Address(update.Address));
            applicant.Set(new EmailAddress(update.EmailAddress));
            applicant.Set(new Age(update.Age));
            applicant.Set(update.CountryOfOrigin);
            applicant.Set(update.Hired);
        }

        public Task<Result<Applicant>> RemoveApplicant(int applicantId)
            => TryCatch(async () =>
            {
                var applicant = await _applicantRepository.FindById(applicantId);
                if (applicant == null)
                {
                    return Result.Failure<Applicant>($"applicant {applicantId} not found!");
                }

                await _applicantRepository.Delete(applicant);
                return Result.Success(applicant);
            });
    }
}