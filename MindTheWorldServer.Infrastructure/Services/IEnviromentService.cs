using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindTheWorldServer.Infrastructure.Services
{
    public interface IEnviromentService
    {
        Task<Dictionary<string, IEnumerable<string>>> ImportCo2Emissions(IFormFile inputFile);
    }
}
