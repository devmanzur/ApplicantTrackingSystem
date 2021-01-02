using System;
using System.Collections.Generic;

namespace Hahn.ApplicatonProcess.December2020.Web.Contracts
{
    public class Envelope<T>
    {
        // ReSharper disable once MemberCanBeProtected.Global
        protected internal Envelope(T body, Dictionary<string,string> errors)
        {
            Body = body;
            Errors = errors;
            TimeGenerated = DateTime.UtcNow;
            IsSuccess = errors == null;
        }

        public T Body { get; }
        public Dictionary<string,string> Errors { get; }
        public DateTime TimeGenerated { get; }
        public bool IsSuccess { get; }
    }

    public class Envelope : Envelope<string>
    {
        private Envelope(Dictionary<string,string> errors)
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

        public static Envelope Error(Dictionary<string,string> errors)
        {
            return new Envelope(errors);
        }

        public static Envelope<T> Error<T>(T error, Dictionary<string,string> errors)
        {
            return new Envelope<T>(error, errors);
        }
    }
}