using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;

namespace Hahn.ApplicatonProcess.December2020.Domain.Interfaces
{
    public interface IApplicantRepository
    {
        Task<Applicant> FindById(int id, CancellationToken cancellationToken = default);
        Task<List<Applicant>> ListAll(CancellationToken cancellationToken = default);
        Task<Applicant> Create(Applicant applicant, CancellationToken cancellationToken = default);
        Task Update(Applicant applicant, CancellationToken cancellationToken = default);
        Task Delete(Applicant applicant, CancellationToken cancellationToken = default);
    }
}