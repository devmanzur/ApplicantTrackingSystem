using System.Collections.Generic;
using Swashbuckle.AspNetCore.Filters;

namespace Hahn.ApplicatonProcess.December2020.Web.Contracts.Examples.Response
{
    public class EnveloperErrorResponseExample : IExamplesProvider<Envelope>
    {
        public Envelope GetExamples()
        {
            return Envelope.Error(new List<PropertyError>()
            {
                new PropertyError("error_property","explanation, what went wrong")
            });
        }
    }
}