using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Hahn.ApplicatonProcess.December2020.Domain.Dto;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Domain.Exceptions;
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

        public Task<Result<Applicant>> CreateApplicantAsync(CreateApplicantDto dto) =>
            TryCatch(async () =>
            {
                await ValidateCreateRequestAsync(dto);

                var applicant = new Applicant(new Name(dto.Name), new FamilyName(dto.FamilyName),
                    new Address(dto.Address), dto.CountryOfOrigin, new EmailAddress(dto.EmailAddress),
                    new Age(dto.Age), dto.Hired);
                await _applicantRepository.AddAsync(applicant);
                return Result.Success(applicant);
            });

        public Task<List<Applicant>> RetrieveAllApplicants() =>
            TryCatch(() => _applicantRepository.ListAllAsync());

        public Task<Result<Applicant>> RetrieveApplicantById(int applicantId) =>
                TryCatch(async () =>
                {
                    var applicant = await _applicantRepository.FindByIdAsync(applicantId);
                    if (applicant == null)
                    {
                        return Result.Failure<Applicant>($"applicant {applicantId} not found!");
                    }

                    return Result.Success(applicant);
                });

        public async Task<Result<Applicant>> ModifyApplicantAsync(int applicantId, UpdateApplicantDto dto)
        {
            var applicant = await _applicantRepository.FindByIdAsync(applicantId);
            if (applicant == null)
            {
                return Result.Failure<Applicant>($"applicant {applicantId} not found!");
            }


            return Result.Success(applicant);
        }

        public Task<Result<Applicant>> DeleteApplicantAsync(int applicantId)
        {
            throw new System.NotImplementedException();
        }
    }
}