using MindTheWorld.UI.Http.Dtos;
using System.Collections.Generic;
using System.Net.Http;
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

        public async Task<List<BarChartDto>> GetEpidemicDeathsAsync()
        {
            var response = await _http.GetAsync("http://localhost:55710/api/epidemicDeaths");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<BarChartDto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, WriteIndented = true });
            return result;
        }
    }
}
