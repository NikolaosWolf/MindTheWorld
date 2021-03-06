using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MindTheWorldServer.Infrastructure.Services;
using System.Threading.Tasks;

namespace MindTheWorldServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Co2EmissionsController : ControllerBase
    {
        private readonly IEnviromentService _enviromentService;

        public Co2EmissionsController(IEnviromentService enviromentService)
        {
            _enviromentService = enviromentService;
        }

        public async Task<IActionResult> Post(IFormFile file)
        {
            var result = await _enviromentService.ImportCo2Emissions(file);

            return Ok(result);
        }
    }
}
