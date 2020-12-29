using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Hahn.ApplicatonProcess.December2020.Domain.Contract;
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

        public ApplicantService(IApplicantRepository applicantRepository, ILoggingBroker loggingBroker, ICountryDataProvider countryDataProvider)
        {
            _applicantRepository = applicantRepository;
            _loggingBroker = loggingBroker;
            _countryDataProvider = countryDataProvider;
        }

        public Task<Result<Applicant>> CreateApplicantAsync(CreateApplicantDto dto) =>
            TryCatch(async () =>
            {
                var fetchCountryData = await _countryDataProvider.GetCountry(dto.CountryOfOrigin);
                if (fetchCountryData.IsFailure)
                {
                    return Result.Failure<Applicant>(fetchCountryData.Error);
                }

                var applicant = new Applicant(new Name(dto.Name), new FamilyName(dto.FamilyName),
                    new Address(dto.Address), fetchCountryData.Value, new EmailAddress(dto.EmailAddress), new Age(dto.Age), dto.Hired);
                await _applicantRepository.AddAsync(applicant);
                return Result.Success(applicant);
            });

        public IReadOnlyList<Applicant> RetrieveAllApplicants()
        {
            throw new System.NotImplementedException();
        }

        public ValueTask<Applicant> RetrieveApplicantById(int applicantId)
        {
            throw new System.NotImplementedException();
        }

        public ValueTask<Applicant> ModifyApplicantAsync(int applicantId, UpdateApplicantDto dto)
        {
            throw new System.NotImplementedException();
        }

        public ValueTask<Applicant> DeleteApplicantAsync(int applicantId)
        {
            throw new System.NotImplementedException();
        }
    }
}