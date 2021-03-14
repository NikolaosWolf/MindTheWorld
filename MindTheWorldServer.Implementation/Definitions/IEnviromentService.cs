using Microsoft.AspNetCore.Http;
using MindTheWorldServer.Api.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindTheWorldServer.Services.Definitions
{
    public interface IEnviromentService
    {
        Task<IEnumerable<Co2EmissionDto>> ImportCo2Emissions(IFormFile inputFile);
    }
}
