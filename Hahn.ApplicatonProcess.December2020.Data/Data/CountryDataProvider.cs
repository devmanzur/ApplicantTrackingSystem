using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;

namespace Hahn.ApplicatonProcess.December2020.Data.Data
{
    public class CountryDataProvider : ICountryDataProvider
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CountryDataProvider(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //https://restcountries.eu/rest/v2/name/{name}?fullText=true
        public async Task<Result> ValidateCountry(string name)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync($"https://restcountries.eu/rest/v2/name/{name}?fullText=true");
            if (response.IsSuccessStatusCode)
            {
                return Result.Success();
            }

            return Result.Failure("failed to validate country");
        }
    }
}