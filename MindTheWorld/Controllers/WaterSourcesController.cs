using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MindTheWorld.Services.Definitions;
using System.Threading.Tasks;

namespace MindTheWorldServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaterSourcesController : ControllerBase
    {
        private readonly IInfrastructureService _infrastructureService;

        public WaterSourcesController(IInfrastructureService infrastructureService)
        {
            _infrastructureService = infrastructureService;
        }

        public async Task<IActionResult> Post(IFormFile file)
        {
            return Ok(await _infrastructureService.ImportWaterSourceAccesses(file));
        }
    }
}
