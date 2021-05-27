using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MindTheWorld.Services.Definitions;
using System.Threading.Tasks;

namespace MindTheWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportController : ControllerBase
    {
        private readonly IEconomyService _economyService;
        private readonly IEducationService _educationService;
        private readonly IEnergyService _energyService;
        private readonly IInfrastructureService _infrastructureService;
        private readonly IPopulationService _populationService;
        private readonly ISocietyService _societyService;
        private readonly IEnviromentService _enviromentService;
        private readonly IHealthService _healthService;

        public ImportController(IEconomyService economyService,
                                IEducationService educationService,
                                IEnergyService energyService,
                                IEnviromentService enviromentService,
                                IHealthService healthService,
                                IInfrastructureService infrastructureService,
                                IPopulationService populationService,
                                ISocietyService societyService)
        {
            _economyService = economyService;
            _educationService = educationService;
            _energyService = energyService;
            _enviromentService = enviromentService;
            _healthService = healthService;
            _infrastructureService = infrastructureService;
            _populationService = populationService;
            _societyService = societyService;
        }

        #region Economy

        [HttpPost]
        [Route("grossdomesticproducts")]
        public async Task<IActionResult> ImportGrossDomesticProducts(IFormFile file)
        {
            return Ok(await _economyService.ImportGrossDomesticProducts(file));
        }

        #endregion

        #region Education

        [HttpPost]
        [Route("adultliteracyrates")]
        public async Task<IActionResult> ImportAdultLiteracyRates(IFormFile file)
        {
            return Ok(await _educationService.ImportAdultLiteracyRates(file));
        }

        #endregion

        #region Energy

        [HttpPost]
        [Route("coalconsumptions")]
        public async Task<IActionResult> ImportCoalConsumptions(IFormFile file)
        {
            return Ok(await _energyService.ImportCoalConsumptions(file));
        }

        [HttpPost]
        [Route("residentialelectricityuses")]
        public async Task<IActionResult> ImportResidentialElectricityUses(IFormFile file)
        {
            return Ok(await _energyService.ImportResidentialElectricityUses(file));
        }

        [HttpPost]
        [Route("oilconsumptions")]
        public async Task<IActionResult> ImportOilConsumptions(IFormFile file)
        {
            return Ok(await _energyService.ImportOilConsumptions(file));
        }

        #endregion

        #region Enviroment

        [HttpPost]
        [Route("co2emissions")]
        public async Task<IActionResult> ImportCo2Emissions(IFormFile file)
        {
            return Ok(await _enviromentService.ImportCo2Emissions(file));
        }

        [HttpPost]
        [Route("epidemicdeaths")]
        public async Task<IActionResult> ImportEpidemicDeaths(IFormFile file)
        {
            return Ok(await _enviromentService.ImportEpidemicDeaths(file));
        }

        [HttpPost]
        [Route("materialfootprints")]
        public async Task<IActionResult> ImportMaterialFootprints(IFormFile file)
        {
            return Ok(await _enviromentService.ImportMaterialFootprints(file));
        }

        [HttpPost]
        [Route("renewablewaters")]
        public async Task<IActionResult> ImportRenewableWaters(IFormFile file)
        {
            return Ok(await _enviromentService.ImportRenewableWaters(file));
        }

        [HttpPost]
        [Route("waterwithdrawals")]
        public async Task<IActionResult> ImportWaterWithdrawals(IFormFile file)
        {
            return Ok(await _enviromentService.ImportWaterWithdrawals(file));
        }

        #endregion

        #region Health

        [HttpPost]
        [Route("infantmortalities")]
        public async Task<IActionResult> ImportInfantMortalities(IFormFile file)
        {
            return Ok(await _healthService.ImportInfantMortalities(file));
        }

        #endregion

        #region Infrastructure

        [HttpPost]
        [Route("watersourceaccesses")]
        public async Task<IActionResult> ImportWaterSourceAccesses(IFormFile file)
        {
            return Ok(await _infrastructureService.ImportWaterSourceAccesses(file));
        }

        #endregion

        #region Population

        [HttpPost]
        [Route("populations")]
        public async Task<IActionResult> ImportPopulations(IFormFile file)
        {
            return Ok(await _populationService.ImportPopulations(file));
        }

        #endregion

        #region Society

        [HttpPost]
        [Route("happinessscores")]
        public async Task<IActionResult> ImportHappinessScores(IFormFile file)
        {
            return Ok(await _societyService.ImportHappinessScores(file));
        }

        [HttpPost]
        [Route("humandevelopmentindexes")]
        public async Task<IActionResult> ImportHumanDevelopmentIndexes(IFormFile file)
        {
            return Ok(await _societyService.ImportHumanDevelopmentIndexes(file));
        }

        #endregion
    }
}
