using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.December2020.Data.Data
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly ApplicantDbContext _dbContext;

        public ApplicantRepository(ApplicantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Applicant> FindByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return _dbContext.Applicants.FirstOrDefaultAsync(x=>x.Id == id, cancellationToken);
        }

        public Task<List<Applicant>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.Applicants.AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
        }

        public async Task<Applicant> AddAsync(Applicant applicant, CancellationToken cancellationToken = default)
        {
            await _dbContext.Applicants.AddAsync(applicant, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return applicant;
        }

        public async Task UpdateAsync(Applicant applicant, CancellationToken cancellationToken = default)
        {
            _dbContext.Applicants.Update(applicant);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Applicant applicant, CancellationToken cancellationToken = default)
        {
            _dbContext.Applicants.Remove(applicant);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}