using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.December2020.Domain.Services
{
    public partial class ApplicantService
    {
        private delegate Task<Result<Applicant>> ReturningApplicantFunction();

        private delegate Task<IReadOnlyList<Applicant>> ReturningApplicantsFunction();


        private async Task<Result<Applicant>> TryCatch(ReturningApplicantFunction returningApplicantFunction)
        {
            try
            {
                return await returningApplicantFunction();
            }
            catch (BusinessRuleViolationException businessRuleViolationException)
            {
                throw CreateAndLogRuleViolationException(businessRuleViolationException);
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                throw CreateAndLogDependencyException(dbUpdateConcurrencyException);
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw CreateAndLogDependencyException(dbUpdateException);
            }
            catch (Exception exception)
            {
                throw CreateAndLogServiceException(exception);
            }
        }

        private async Task<IReadOnlyList<Applicant>> TryCatch(ReturningApplicantsFunction returningApplicantsFunction)
        {
            try
            {
                return await returningApplicantsFunction();
            }
            catch (Exception exception)
            {
                throw CreateAndLogServiceException(exception);
            }
        }


        private ApplicantServiceException CreateAndLogServiceException(Exception exception)
        {
            var applicantServiceException = new ApplicantServiceException(exception);
            _loggingBroker.LogError(exception);
            return applicantServiceException;
        }
        
        private BusinessRuleViolationException CreateAndLogRuleViolationException(BusinessRuleViolationException exception)
        {
            _loggingBroker.LogCritical(exception);
            return exception;
        }

        private ApplicantDependencyException CreateAndLogDependencyException(Exception exception)
        {
            var applicantDependencyException = new ApplicantDependencyException(exception);
            _loggingBroker.LogError(exception);

            return applicantDependencyException;
        }

    }
}