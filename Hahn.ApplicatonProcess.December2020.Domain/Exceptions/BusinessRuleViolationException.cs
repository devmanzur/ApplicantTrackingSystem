using System;
using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;

namespace Hahn.ApplicatonProcess.December2020.Domain.Exceptions
{
    public class BusinessRuleViolationException : Exception
    {
        public IBusinessRule BrokenRule { get; }

        public BusinessRuleViolationException(IBusinessRule brokenRule) : base(brokenRule.Message)
        {
            BrokenRule = brokenRule;
        }
    }
}