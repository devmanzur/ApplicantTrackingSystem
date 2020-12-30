using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;

namespace Hahn.ApplicatonProcess.December2020.Domain.Interfaces
{
    public interface IApplicantRepository
    {
        Task<Applicant> FindByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<Applicant>> ListAllAsync(CancellationToken cancellationToken = default);
        Task<Applicant> AddAsync(Applicant applicant, CancellationToken cancellationToken = default);
        Task UpdateAsync(Applicant applicant, CancellationToken cancellationToken = default);
        Task DeleteAsync(Applicant applicant, CancellationToken cancellationToken = default);
    }
}