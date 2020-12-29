using System;

namespace Hahn.ApplicatonProcess.December2020.Domain.Exceptions
{
    public class ApplicantServiceException : Exception
    {
        public ApplicantServiceException(Exception innerException) : base("Service error occurred, contact support.",
            innerException)
        {
        }
    }
}