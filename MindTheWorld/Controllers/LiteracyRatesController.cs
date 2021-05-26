using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MindTheWorld.Services.Definitions;
using System.Threading.Tasks;

namespace MindTheWorldServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiteracyRatesController : ControllerBase
    {
        private readonly IEducationService _educationService;

        public LiteracyRatesController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        public async Task<IActionResult> Post(IFormFile file)
        {
            return Ok(await _educationService.ImportAdultLiteracyRates(file));
        }
    }
}
