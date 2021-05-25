using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MindTheWorldServer.Services.Definitions;
using System.Threading.Tasks;

namespace MindTheWorldServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialFootprintsController : ControllerBase
    {
        private readonly IEnviromentService _enviromentService;

        public MaterialFootprintsController(IEnviromentService enviromentService)
        {
            _enviromentService = enviromentService;
        }

        public async Task<IActionResult> Post(IFormFile file)
        {
            return Ok(await _enviromentService.ImportMaterialFootprints(file));
        }
    }
}
