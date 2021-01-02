using System;
using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Hahn.ApplicatonProcess.December2020.Data.Logs
{
    public class LoggingBroker : ILoggingBroker
    {
        private readonly ILogger<LoggingBroker> _logger;

        public LoggingBroker(ILogger<LoggingBroker> logger)
        {
            _logger = logger;
        }

        public void LogCritical(Exception exception) =>
            _logger.LogCritical(exception, exception.Message);

        public void LogDebug(string message) =>
            _logger.LogDebug(message);

        public void LogError(Exception exception) =>
            _logger.LogError(exception.Message, exception);

        public void LogInformation(string message, object[] parameters) =>
            _logger.LogInformation(message, parameters);

        public void LogTrace(string message) =>
            _logger.LogTrace(message);

        public void LogWarning(string message) =>
            _logger.LogWarning(message);
    }
}