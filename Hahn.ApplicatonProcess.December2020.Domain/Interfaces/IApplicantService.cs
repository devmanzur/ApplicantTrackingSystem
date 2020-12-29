using System.Linq;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;

namespace Hahn.ApplicatonProcess.December2020.Domain.Interfaces
{
    public interface IApplicantService
    {
        ValueTask<Applicant> CreateApplicantAsync(Applicant applicant);
        IQueryable<Applicant> RetrieveAllApplicants();
        ValueTask<Applicant> RetrieveApplicantById(int applicantId);
        ValueTask<Applicant> ModifyApplicantAsync(Applicant applicant);
        ValueTask<Applicant> DeleteApplicantAsync(int applicantId);
    }
}