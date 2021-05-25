﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MindTheWorldServer.Services.Definitions;
using System.Threading.Tasks;

namespace MindTheWorldServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanDevelopmentIndexesController : ControllerBase
    {
        private readonly ISocietyService _societyService;

        public HumanDevelopmentIndexesController(ISocietyService societyService)
        {

            _societyService = societyService;
        }

        public async Task<IActionResult> Post(IFormFile file)
        {
            return Ok(await _societyService.ImportHumanDevelopmentIndexes(file));
        }
    }
}