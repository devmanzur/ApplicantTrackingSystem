using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Hahn.ApplicatonProcess.December2020.Domain.Dto;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;

namespace Hahn.ApplicatonProcess.December2020.Domain.Interfaces
{
    public interface IApplicantService
    {
        Task<Result<Applicant>> RegisterApplicant(ApplicantDto dto);
        Task<List<Applicant>> RetrieveAllApplicants();
        Task<Result<Applicant>> RetrieveApplicantById(int applicantId);
        Task<Result<Applicant>> ModifyApplicant(int applicantId, ApplicantDto update);
        Task<Result<Applicant>> RemoveApplicant(int applicantId);
    }
}