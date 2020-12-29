using System.Linq;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;

namespace Hahn.ApplicatonProcess.December2020.Domain.Services
{
    public class ApplicantService : IApplicantService
    {
        public ValueTask<Applicant> CreateApplicantAsync(Applicant applicant)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Applicant> RetrieveAllApplicants()
        {
            throw new System.NotImplementedException();
        }

        public ValueTask<Applicant> RetrieveApplicantById(int applicantId)
        {
            throw new System.NotImplementedException();
        }

        public ValueTask<Applicant> ModifyApplicantAsync(Applicant applicant)
        {
            throw new System.NotImplementedException();
        }

        public ValueTask<Applicant> DeleteApplicantAsync(int applicantId)
        {
            throw new System.NotImplementedException();
        }
    }
}