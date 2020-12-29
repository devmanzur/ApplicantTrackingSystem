using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Domain.Contract;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;

namespace Hahn.ApplicatonProcess.December2020.Domain.Interfaces
{
    public interface IApplicantService
    {
        ValueTask<Applicant> CreateApplicantAsync(CreateApplicantDto dto);
        IReadOnlyList<Applicant> RetrieveAllApplicants();
        ValueTask<Applicant> RetrieveApplicantById(int applicantId);
        ValueTask<Applicant> ModifyApplicantAsync(int applicantId, UpdateApplicantDto dto);
        ValueTask<Applicant> DeleteApplicantAsync(int applicantId);
    }
}