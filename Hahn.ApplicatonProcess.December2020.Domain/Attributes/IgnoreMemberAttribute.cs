﻿﻿using System;

  namespace Hahn.ApplicatonProcess.December2020.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class IgnoreMemberAttribute : Attribute
    {
    }
}