using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace Hahn.ApplicatonProcess.December2020.Domain.Interfaces
{
    public interface ICountryDataProvider
    {
        Task<Result<string>> GetCountry(string name);
    }
}