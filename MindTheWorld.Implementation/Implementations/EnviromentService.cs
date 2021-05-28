using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MindTheWorld.Api.Dtos;
using MindTheWorld.Domain;
using MindTheWorld.Extras.Helpers;
using MindTheWorld.Services.Definitions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindTheWorld.Services.Implementations
{
    public class EnviromentService : IEnviromentService
    {
        private readonly ICsvTransformer _csvTransformer;
        private readonly ITransformService _transformService;
        private readonly MindTheWorldContext _mindTheWorldContext;

        public EnviromentService(ICsvTransformer csvTransformer,
                                 ITransformService transformService,
                                 MindTheWorldContext mindTheWorldContext)
        {
            _csvTransformer = csvTransformer;
            _transformService = transformService;
            _mindTheWorldContext = mindTheWorldContext;
        }

        public async Task<IEnumerable<IndexDto>> GetMaterialFootprintsAsync()
        {
            var data = await _mindTheWorldContext.MaterialFootprintPerCapita.Include(d => d.Country).ToListAsync();

            var result = new List<IndexDto>();

            foreach (var item in data)
            {
                result.Add(new IndexDto
                {
                    Country = item.Country.Name,
                    Year = item.Year,
                    Value = item.Value.GetValueOrDefault()
                });
            }

            return result;
        }

        public async Task<IEnumerable<IndexDto>> GetCo2EmissionsAsync()
        {
            var data = await _mindTheWorldContext.Co2EmissionsPerPeople.Include(d => d.Country).ToListAsync();

            var result = new List<IndexDto>();

            foreach (var item in data)
            {
                result.Add(new IndexDto
                {
                    Country = item.Country.Name,
                    Year = item.Year,
                    Value = item.Value.GetValueOrDefault()
                });
            }

            return result;
        }

        public async Task<IEnumerable<IndexDto>> GetEpidemicDeathsAsync()
        {
            var data = await _mindTheWorldContext.EpidemicDeaths.Include(d => d.Country).ToListAsync();

            var result = new List<IndexDto>();

            foreach (var item in data)
            {
                result.Add(new IndexDto
                {
                    Country = item.Country.Name,
                    Year = item.Year,
                    Value = item.Value.GetValueOrDefault()
                });
            }

            return result;
        }

        public async Task<IEnumerable<IndexDto>> GetRenewableWatersAsync()
        {
            var data = await _mindTheWorldContext.RenewableWaters.Include(d => d.Country).ToListAsync();

            var result = new List<IndexDto>();

            foreach (var item in data)
            {
                result.Add(new IndexDto
                {
                    Country = item.Country.Name,
                    Year = item.Year,
                    Value = item.Value.GetValueOrDefault()
                });
            }

            return result;
        }

        public async Task<IEnumerable<IndexDto>> GetWaterWithdrawals()
        {
            var data = await _mindTheWorldContext.WaterWithdrawlPerPeople.Include(d => d.Country).ToListAsync();

            var result = new List<IndexDto>();

            foreach (var item in data)
            {
                result.Add(new IndexDto
                {
                    Country = item.Country.Name,
                    Year = item.Year,
                    Value = item.Value.GetValueOrDefault()
                });
            }

            return result;
        }

        public async Task<IEnumerable<MaterialFootprintPerCapitum>> ImportMaterialFootprints(IFormFile inputFile)
        {
            var dataTable = await _csvTransformer.Transform(inputFile);

            _mindTheWorldContext
                .MaterialFootprintPerCapita
                .AddRange(await _transformService.ToEntities<MaterialFootprintPerCapitum>(dataTable));

            await _mindTheWorldContext.SaveChangesAsync();

            return null;
        }

        public async Task<IEnumerable<Co2EmissionsPerPerson>> ImportCo2Emissions(IFormFile inputFile)
        {
            var dataTable = await _csvTransformer.Transform(inputFile);

            _mindTheWorldContext
                .Co2EmissionsPerPeople
                .AddRange(await _transformService.ToEntities<Co2EmissionsPerPerson>(dataTable));

            await _mindTheWorldContext.SaveChangesAsync();

            return null;
        }

        public async Task<IEnumerable<EpidemicDeath>> ImportEpidemicDeaths(IFormFile inputFile)
        {
            var dataTable = await _csvTransformer.Transform(inputFile);

            _mindTheWorldContext
                .EpidemicDeaths
                .AddRange(await _transformService.ToEntities<EpidemicDeath>(dataTable));

            await _mindTheWorldContext.SaveChangesAsync();

            return null;
        }

        public async Task<IEnumerable<RenewableWater>> ImportRenewableWaters(IFormFile inputFile)
        {
            var dataTable = await _csvTransformer.Transform(inputFile);

            _mindTheWorldContext
                .RenewableWaters
                .AddRange(await _transformService.ToEntities<RenewableWater>(dataTable));

            await _mindTheWorldContext.SaveChangesAsync();

            return null;
        }

        public async Task<IEnumerable<WaterWithdrawlPerPerson>> ImportWaterWithdrawals(IFormFile inputFile)
        {
            var dataTable = await _csvTransformer.Transform(inputFile);

            _mindTheWorldContext
                .WaterWithdrawlPerPeople
                .AddRange(await _transformService.ToEntities<WaterWithdrawlPerPerson>(dataTable));

            await _mindTheWorldContext.SaveChangesAsync();

            return null;
        }

        
    }
}
