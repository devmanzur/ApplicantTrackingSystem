using System;
using System.Collections.Generic;

namespace Hahn.ApplicatonProcess.December2020.Domain.Exceptions
{
    public class ApplicantPropertyValidationException : Exception
    {
        public Dictionary<string,string> Errors { get; }

        public ApplicantPropertyValidationException(Dictionary<string,string> errors) : base("one or more rules were violated")
        {
            Errors = errors;
        }
    }
}