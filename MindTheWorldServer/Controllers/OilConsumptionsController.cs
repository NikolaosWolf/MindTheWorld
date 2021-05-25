using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MindTheWorldServer.Services.Definitions;
using System.Threading.Tasks;

namespace MindTheWorldServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OilConsumptionsController : ControllerBase
    {
        private readonly IEnergyService _energyService;

        public OilConsumptionsController(IEnergyService energyService)
        {
            _energyService = energyService;
        }

        public async Task<IActionResult> Post(IFormFile file)
        {
            return Ok(await _energyService.ImportOilConsumptions(file));
        }
    }
}
