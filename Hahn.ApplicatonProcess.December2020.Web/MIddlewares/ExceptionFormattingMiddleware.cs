using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Domain.Exceptions;
using Hahn.ApplicatonProcess.December2020.Web.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Hahn.ApplicatonProcess.December2020.Web.MIddlewares
{
    public class ExceptionFormattingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public ExceptionFormattingMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleException(httpContext, ex, _env);
            }
        }

        private Task HandleException(HttpContext context, Exception exception, IWebHostEnvironment env)
        {
            var code = HttpStatusCode.InternalServerError;
            var errors = new List<PropertyError>()
            {
                new PropertyError("action", _env.IsDevelopment()
                    ? exception.Message
                    : DummyMessage())
            };

            switch (exception)
            {
                case BusinessRuleViolationException businessRuleViolationException:
                    code = HttpStatusCode.UnprocessableEntity;
                    errors = new List<PropertyError>()
                    {
                        new PropertyError(
                            businessRuleViolationException.BrokenRule.PropertyName,
                            businessRuleViolationException.BrokenRule.ErrorMessage
                        )
                    };
                    break;
                case ApplicantPropertyValidationException validationException:
                    code = HttpStatusCode.UnprocessableEntity;
                    errors = validationException.Errors.Select(x => new PropertyError(x.Key, x.Value)).ToList();
                    break;
            }

            var envelope = Envelope.Error(errors);
            var result = JsonConvert.SerializeObject(envelope);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) code;
            return context.Response.WriteAsync(result);
        }

        private static string DummyMessage()
        {
            return "Something wrong on our side, Please try again later";
        }
    }
}