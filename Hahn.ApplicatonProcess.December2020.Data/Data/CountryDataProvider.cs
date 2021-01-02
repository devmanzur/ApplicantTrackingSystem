using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;

namespace Hahn.ApplicatonProcess.December2020.Data.Data
{
    public class CountryDataProvider : ICountryDataProvider
    {
        public Task<Result<string>> GetCountry(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}