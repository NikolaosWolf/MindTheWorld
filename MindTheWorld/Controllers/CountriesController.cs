using Microsoft.AspNetCore.Mvc;
using MindTheWorld.Services.Definitions;
using System.Threading.Tasks;

namespace MindTheWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            return Ok(await _countryService.GetCountriesAsync());
        }

        [HttpGet]
        [Route("{countryId:int}")]
        public async Task<IActionResult> GetPointsByCountry(int countryId, string firstIndex, string secondIndex)
        {
            return Ok(await _countryService.GetIndexPointsByCountryAsync(countryId, firstIndex, secondIndex));
        }
    }
}
