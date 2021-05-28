using MindTheWorld.UI.Http.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindTheWorld.UI.Http
{
    public interface IMindTheWorldHttpClient
    {
        Task<IEnumerable<string>> GetIndexTypesAsync();

        Task<IEnumerable<CountryDto>> GetCountriesAsync();

        Task<List<LineChartDto>> GetIndexValuesForLineAsync(string index);

        Task<List<BarChartDto>> GetIndexValuesForBarAsync(string index);

        Task<List<ScatterPointChartDto>> GetIndexValuesForScatterAsync(int countryId, string firstIndex, string secondIndex);
    }
}
