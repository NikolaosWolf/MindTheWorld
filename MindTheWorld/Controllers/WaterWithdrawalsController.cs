using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MindTheWorld.Services.Definitions;
using System.Threading.Tasks;

namespace MindTheWorldServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaterWithdrawalsController : ControllerBase
    {
        private readonly IEnviromentService _enviromentService;

        public WaterWithdrawalsController(IEnviromentService enviromentService)
        {
            _enviromentService = enviromentService;
        }

        public async Task<IActionResult> Post(IFormFile file)
        {
            return Ok(await _enviromentService.ImportWaterWithdrawals(file));
        }
    }
}
