using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Domain.Contract;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;

namespace Hahn.ApplicatonProcess.December2020.Domain.Services
{
    public partial class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly ILoggingBroker _loggingBroker;

        public ApplicantService(IApplicantRepository applicantRepository, ILoggingBroker loggingBroker)
        {
            _applicantRepository = applicantRepository;
            _loggingBroker = loggingBroker;
        }
        public ValueTask<Applicant> CreateApplicantAsync(CreateApplicantDto dto)
        {
            throw new System.NotImplementedException();
        }

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