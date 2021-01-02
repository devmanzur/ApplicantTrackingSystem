using System;
using System.Collections.Generic;
using System.Linq;

namespace Hahn.ApplicatonProcess.December2020.Web.Contracts
{
    public class Envelope<T>
    {
        // ReSharper disable once MemberCanBeProtected.Global
        protected internal Envelope(T body, Dictionary<string, string> errors)
        {
            Body = body;
            Errors = errors?.Select(x => new PropertyError(x)).ToList();
            TimeGenerated = DateTime.UtcNow;
            IsSuccess = errors == null;
        }

        public T Body { get; }
        public List<PropertyError> Errors { get; }
        public DateTime TimeGenerated { get; }
        public bool IsSuccess { get; }
    }

    public class PropertyError
    {
        public PropertyError(in KeyValuePair<string, string> keyValuePair)
        {
            PropertyName = keyValuePair.Key;
            ErrorMessage = keyValuePair.Value;
        }

        public string PropertyName { get; private set; }
        public string ErrorMessage { get; private set; }
    }

    public class Envelope : Envelope<string>
    {
        private Envelope(Dictionary<string, string> errors)
            : base(errors == null ? null : "success", errors)
        {
        }

        public static Envelope<T> Ok<T>(T result)
        {
            return new Envelope<T>(result, null);
        }

        public static Envelope Ok()
        {
            return new Envelope(null);
        }

        public static Envelope Error(Dictionary<string, string> errors)
        {
            return new Envelope(errors);
        }

        public static Envelope Error(string error)
        {
            return new Envelope(new Dictionary<string, string>()
            {
                {"action", error}
            });
        }

        public static Envelope<T> Error<T>(T error, Dictionary<string, string> errors)
        {
            return new Envelope<T>(error, errors);
        }
    }
}