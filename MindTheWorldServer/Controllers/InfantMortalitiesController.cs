using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MindTheWorldServer.Services.Definitions;
using System.Threading.Tasks;

namespace MindTheWorldServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfantMortalitiesController : ControllerBase
    {
        private readonly IHealthService _healthService;

        public InfantMortalitiesController(IHealthService healthService)
        {
            _healthService = healthService;
        }

        public async Task<IActionResult> Post(IFormFile file)
        {
            return Ok(await _healthService.ImportInfantMortalities(file));
        }
    }
}
