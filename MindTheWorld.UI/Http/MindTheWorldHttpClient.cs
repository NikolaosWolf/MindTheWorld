using MindTheWorld.UI.Http.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace MindTheWorld.UI.Http
{
    public class MindTheWorldHttpClient : IMindTheWorldHttpClient
    {
        private readonly HttpClient _http;

        public MindTheWorldHttpClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<string>> GetIndexTypesAsync()
        {
            var response = await _http.GetAsync("http://localhost:55710/api/indexes");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<string>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, WriteIndented = true });
            return result;
        }

        public async Task<IEnumerable<CountryDto>> GetCountriesAsync()
        {
            var response = await _http.GetAsync("http://localhost:55710/api/countries");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<CountryDto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, WriteIndented = true });
            return result;
        }

        public async Task<List<LineChartDto>> GetIndexValuesForLineAsync(string index)
        {
            string uri = ConstructToIndexUri(index);
            var result = await _http.GetFromJsonAsync<List<LineChartDto>>(uri);
            return result;
        }

        public async Task<List<BarChartDto>> GetIndexValuesForBarAsync(string index)
        {
            string uri = ConstructToIndexUri(index);
            var response = await _http.GetAsync(uri);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<BarChartDto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, WriteIndented = true });
            return result;
        }

        public async Task<List<ScatterPointChartDto>> GetIndexValuesForScatterAsync(int countryId, string firstIndex, string secondIndex)
        {
            string uri = ConstructToPointUri(countryId, firstIndex, secondIndex);
            var response = await _http.GetAsync(uri);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<ScatterPointChartDto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, WriteIndented = true });
            return result;
        }

        private string ConstructToPointUri(int countryId, string firstIndex, string secondIndex)
        {
            return $"http://localhost:55710/api/countries/{countryId}?firstIndex={firstIndex}&secondIndex={secondIndex}";
        }

        private string ConstructToIndexUri(string index)
        {
            string baseUri = "http://localhost:55710/api/indexes/";

            if (index.Equals("Co2Emissions", System.StringComparison.InvariantCultureIgnoreCase))
                return baseUri + "co2emissions";

            if (index.Equals("CoalConsumption", System.StringComparison.InvariantCultureIgnoreCase))
                return baseUri + "coalconsumptions";

            if (index.Equals("EpidemicDeaths", System.StringComparison.InvariantCultureIgnoreCase))
                return baseUri + "epidemicdeaths";

            if (index.Equals("GrossDomesticProduct", System.StringComparison.InvariantCultureIgnoreCase))
                return baseUri + "grossdomesticproducts";

            if (index.Equals("HappinessScore", System.StringComparison.InvariantCultureIgnoreCase))
                return baseUri + "happinessscores";

            if (index.Equals("HumanDevelopmentIndex", System.StringComparison.InvariantCultureIgnoreCase))
                return baseUri + "humandevelopmentindexes";

            if (index.Equals("InfantMortalities", System.StringComparison.InvariantCultureIgnoreCase))
                return baseUri + "infantmortalities";

            if (index.Equals("LiiteracyRateForAdults", System.StringComparison.InvariantCultureIgnoreCase))
                return baseUri + "adultliteracyrates";

            if (index.Equals("MaterialFootprint", System.StringComparison.InvariantCultureIgnoreCase))
                return baseUri + "materialfootprints";

            if (index.Equals("OilConsumption", System.StringComparison.InvariantCultureIgnoreCase))
                return baseUri + "oilconsumptions";

            if (index.Equals("Population", System.StringComparison.InvariantCultureIgnoreCase))
                return baseUri + "populations";

            if (index.Equals("RenewableWater", System.StringComparison.InvariantCultureIgnoreCase))
                return baseUri + "renewablewaters";

            if (index.Equals("ResidentialElectricityUse", System.StringComparison.InvariantCultureIgnoreCase))
                return baseUri + "residentialelectricityuses";

            if (index.Equals("WaterSourceAccess", System.StringComparison.InvariantCultureIgnoreCase))
                return baseUri + "watersourceaccesses";

            if (index.Equals("WaterWithdrawalPerPerson", System.StringComparison.InvariantCultureIgnoreCase))
                return baseUri + "waterwithdrawals";

            return string.Empty;
        }
    }
}
