﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MindTheWorld.Services.Definitions;
using System.Threading.Tasks;

namespace MindTheWorldServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpidemicDeathsController : ControllerBase
    {
        private readonly IEnviromentService _enviromentService;

        public EpidemicDeathsController(IEnviromentService enviromentService)
        {
            _enviromentService = enviromentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _enviromentService.GetEpidemicDeathsAsync());
        }

        
    }
}
