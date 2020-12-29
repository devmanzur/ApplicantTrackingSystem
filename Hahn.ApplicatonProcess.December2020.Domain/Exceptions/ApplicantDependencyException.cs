using System;

namespace Hahn.ApplicatonProcess.December2020.Domain.Exceptions
{
    public class ApplicantDependencyException : Exception
    {
        public ApplicantDependencyException(Exception innerException)
            : base("Service dependency error occurred, contact support.", innerException) { }
    }
}