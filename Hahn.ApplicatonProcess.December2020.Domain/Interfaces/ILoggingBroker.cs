using System;

namespace Hahn.ApplicatonProcess.December2020.Domain.Interfaces
{
    public interface ILoggingBroker
    {
        public void LogInformation(string message,params object[] parameters);
        public void LogInformation(string message);
        public void LogTrace(string message);
        public void LogDebug(string message);
        public void LogWarning(string message);
        public void LogError(Exception exception);
        public void LogCritical(Exception exception);
    }
}