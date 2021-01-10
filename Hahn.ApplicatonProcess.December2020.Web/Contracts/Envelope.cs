using System;
using System.Collections.Generic;
using System.Linq;

namespace Hahn.ApplicatonProcess.December2020.Web.Contracts
{
    public class Envelope<T>
    {
        // ReSharper disable once MemberCanBeProtected.Global
        protected internal Envelope(T body, List<PropertyError>  errors)
        {
            Body = body;
            Errors = errors;
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
        public PropertyError(string name, string message)
        {
            PropertyName = name;
            ErrorMessage = message;
        }

        public string PropertyName { get; private set; }
        public string ErrorMessage { get; private set; }
    }

    public class Envelope : Envelope<string>
    {
        private Envelope(List<PropertyError> errors)
            : base(errors == null ? "success" : null, errors)
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

        public static Envelope Error(List<PropertyError> errors)
        {
            return new Envelope(errors);
        }

        public static Envelope Error(string error)
        {
            return new Envelope(new List<PropertyError>()
            {
                new PropertyError("action", error)
            });
        }

        public static Envelope<T> Error<T>(T error, List<PropertyError> errors)
        {
            return new Envelope<T>(error, errors);
        }
    }
}