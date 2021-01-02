using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;

namespace Hahn.ApplicatonProcess.December2020.Domain.Services
{
    public partial class ApplicantService
    {
        public Task<List<Applicant>> RetrieveAllApplicants() =>
            TryCatch(() => _applicantRepository.ListAll());

        public Task<Result<Applicant>> RetrieveApplicantById(int applicantId) =>
            TryCatch(async () =>
            {
                var applicant = await _applicantRepository.FindById(applicantId);
                if (applicant == null)
                {
                    return Result.Failure<Applicant>($"applicant {applicantId} not found!");
                }

                return Result.Success(applicant);
            });
    }
}