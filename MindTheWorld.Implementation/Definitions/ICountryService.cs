using MindTheWorld.Api.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindTheWorld.Services.Definitions
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDto>> GetCountriesAsync();

        Task<IEnumerable<PointDto>> GetIndexPointsByCountryAsync(int countryId, string firstIndex, string secondIndex);
    }
}
