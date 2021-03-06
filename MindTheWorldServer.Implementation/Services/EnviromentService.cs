using Microsoft.AspNetCore.Http;
using MindTheWorldServer.Extras.Helpers;
using MindTheWorldServer.Infrastructure.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindTheWorldServer.Implementation.Services
{
    public class EnviromentService : IEnviromentService
    {
        private readonly ICsvTransformer _csvTransformer;

        public EnviromentService(ICsvTransformer csvTransformer)
        {
            _csvTransformer = csvTransformer;
        }

        public async Task<Dictionary<string, IEnumerable<string>>> ImportCo2Emissions(IFormFile inputFile)
        {
            return await _csvTransformer.Transform(inputFile);
        }
    }
}
