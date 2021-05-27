using MindTheWorld.UI.Http.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindTheWorld.UI.Http
{
    public interface IMindTheWorldHttpClient
    {
        Task<List<BarChartDto>> GetEpidemicDeathsAsync();
    }
}
