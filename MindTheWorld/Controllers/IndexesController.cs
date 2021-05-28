using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MindTheWorld.Services.Definitions;
using System.Threading.Tasks;

namespace MindTheWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndexesController : ControllerBase
    {
        private readonly ICommonService _commonService;
        private readonly IEconomyService _economyService;
        private readonly IEducationService _educationService;
        private readonly IEnergyService _energyService;
        private readonly IInfrastructureService _infrastructureService;
        private readonly IPopulationService _populationService;
        private readonly ISocietyService _societyService;
        private readonly IEnviromentService _enviromentService;
        private readonly IHealthService _healthService;

        public IndexesController(ICommonService commonService,
                                 IEconomyService economyService,
                                 IEducationService educationService,
                                 IEnergyService energyService,
                                 IEnviromentService enviromentService,
                                 IHealthService healthService,
                                 IInfrastructureService infrastructureService,
                                 IPopulationService populationService,
                                 ISocietyService societyService)
        {
            _commonService = commonService;
            _economyService = economyService;
            _educationService = educationService;
            _energyService = energyService;
            _enviromentService = enviromentService;
            _healthService = healthService;
            _infrastructureService = infrastructureService;
            _populationService = populationService;
            _societyService = societyService;
        }

        [HttpGet]
        public IActionResult GetAllIndexTypes()
        {
            return Ok(_commonService.GetIndexTypes());
        }

        #region Economy

        [HttpGet]
        [Route("grossdomesticproducts")]
        public async Task<IActionResult> GetGrossDomesticProducts()
        {
            return Ok(await _economyService.GetGrossDomesticProductsAsync());
        }

        #endregion

        #region Education

        [HttpGet]
        [Route("adultliteracyrates")]
        public async Task<IActionResult> ImportAdultLiteracyRates()
        {
            return Ok(await _educationService.GetAdultLiteracyRatesAsync());
        }

        #endregion

        #region Energy

        [HttpGet]
        [Route("coalconsumptions")]
        public async Task<IActionResult> GetCoalConsumptions()
        {
            return Ok(await _energyService.GetCoalConsumptionsAsync());
        }

        [HttpGet]
        [Route("residentialelectricityuses")]
        public async Task<IActionResult> GetResidentialElectricityUses()
        {
            return Ok(await _energyService.GetResidentialElectricityUsesAsync());
        }

        [HttpGet]
        [Route("oilconsumptions")]
        public async Task<IActionResult> GetOilConsumptions()
        {
            return Ok(await _energyService.GetOilConsumptionsAsync());
        }

        #endregion

        #region Enviroment

        [HttpGet]
        [Route("co2emissions")]
        public async Task<IActionResult> GetCo2Emissions()
        {
            return Ok(await _enviromentService.GetCo2EmissionsAsync());
        }

        [HttpGet]
        [Route("epidemicdeaths")]
        public async Task<IActionResult> GetEpidemicDeaths()
        {
            return Ok(await _enviromentService.GetEpidemicDeathsAsync());
        }

        [HttpGet]
        [Route("materialfootprints")]
        public async Task<IActionResult> GetMaterialFootprints()
        {
            return Ok(await _enviromentService.GetMaterialFootprintsAsync());
        }

        [HttpGet]
        [Route("renewablewaters")]
        public async Task<IActionResult> GetRenewableWaters()
        {
            return Ok(await _enviromentService.GetRenewableWatersAsync());
        }

        [HttpGet]
        [Route("waterwithdrawals")]
        public async Task<IActionResult> ImportWaterWithdrawals()
        {
            return Ok(await _enviromentService.GetWaterWithdrawals());
        }

        #endregion

        #region Health

        [HttpGet]
        [Route("infantmortalities")]
        public async Task<IActionResult> GetInfantMortalities()
        {
            return Ok(await _healthService.GetInfantMortalitiesAsync());
        }

        #endregion

        #region Infrastructure

        [HttpGet]
        [Route("watersourceaccesses")]
        public async Task<IActionResult> GetWaterSourceAccesses()
        {
            return Ok(await _infrastructureService.GetWaterSourceAccessesAsync());
        }

        #endregion

        #region Population

        [HttpGet]
        [Route("populations")]
        public async Task<IActionResult> GetPopulations()
        {
            return Ok(await _populationService.GetPopulationsAsync());
        }

        #endregion

        #region Society

        [HttpGet]
        [Route("happinessscores")]
        public async Task<IActionResult> GetHappinessScores()
        {
            return Ok(await _societyService.GetHappinessScoresAsync());
        }

        [HttpGet]
        [Route("humandevelopmentindexes")]
        public async Task<IActionResult> GetHumanDevelopmentIndexes()
        {
            return Ok(await _societyService.GetHumanDevelopmentIndexesAsync());
        }

        #endregion
    }
}
