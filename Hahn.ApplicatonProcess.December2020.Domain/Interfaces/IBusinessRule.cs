﻿﻿﻿namespace Hahn.ApplicatonProcess.December2020.Domain.Interfaces
{
    public interface IBusinessRule
    {
        bool IsBroken();

        string ErrorMessage { get; }
        string PropertyName { get; }
    }
}