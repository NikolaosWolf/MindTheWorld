using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MindTheWorld.Services.Definitions;
using System.Threading.Tasks;

namespace MindTheWorldServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HappinessScoresController : ControllerBase
    {
        private readonly ISocietyService _societyService;

        public HappinessScoresController(ISocietyService societyService)
        {

            _societyService = societyService;
        }

        public async Task<IActionResult> Post(IFormFile file)
        {
            return Ok(await _societyService.ImportHappinessScores(file));
        }
    }
}
