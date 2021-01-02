using System;

namespace Hahn.ApplicatonProcess.December2020.Domain.Interfaces
{
    public interface ILoggingBroker
    {
        public void LogInformation(string message, object[] parameters);
        public void LogTrace(string message);
        public void LogDebug(string message);
        public void LogWarning(string message);
        public void LogError(Exception exception);
        public void LogCritical(Exception exception);
    }
}