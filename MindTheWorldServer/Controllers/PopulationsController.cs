using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MindTheWorldServer.Services.Definitions;
using System.Threading.Tasks;

namespace MindTheWorldServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopulationsController : ControllerBase
    {
        private readonly IPopulationService _populationService;

        public PopulationsController(IPopulationService populationService)
        {
            _populationService = populationService;
        }

        public async Task<IActionResult> Post(IFormFile file)
        {
            return Ok(await _populationService.ImportPopulations(file));
        }
    }
}
