using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MindTheWorld.Services.Definitions;
using System.Threading.Tasks;

namespace MindTheWorldServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrossDomesticProductsController : ControllerBase
    {
        private readonly IEconomyService _economyService;

        public GrossDomesticProductsController(IEconomyService economyService)
        {
            _economyService = economyService;
        }

        public async Task<IActionResult> Post(IFormFile file)
        {
            return Ok(await _economyService.ImportGrossDomesticProducts(file));
        }
    }
}
