using Microsoft.AspNetCore.Http;
using MindTheWorld.Domain;
using MindTheWorld.Extras.Helpers;
using MindTheWorld.Services.Definitions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindTheWorld.Services.Implementations
{
    public class EnergyService : IEnergyService
    {
        private readonly ICsvTransformer _csvTransformer;
        private readonly ITransformService _transformService;
        private readonly MindTheWorldContext _mindTheWorldContext;

        public EnergyService(ICsvTransformer csvTransformer,
                             ITransformService transformService,
                             MindTheWorldContext mindTheWorldContext)
        {
            _csvTransformer = csvTransformer;
            _transformService = transformService;
            _mindTheWorldContext = mindTheWorldContext;
        }

        public async Task<IEnumerable<ResidentialElectricityUse>> ImportResidentialElectricityUses(IFormFile inputFile)
        {
            var dataTable = await _csvTransformer.Transform(inputFile);

            _mindTheWorldContext
                .ResidentialElectricityUses
                .AddRange(await _transformService.ToEntities<ResidentialElectricityUse, decimal?>(dataTable));

            await _mindTheWorldContext.SaveChangesAsync();

            return null;
        }

        public async Task<IEnumerable<CoalConsumption>> ImportCoalConsumptions(IFormFile inputFile)
        {
            var dataTable = await _csvTransformer.Transform(inputFile);

            _mindTheWorldContext
                .CoalConsumptions
                .AddRange(await _transformService.ToEntities<CoalConsumption, decimal?>(dataTable));

            await _mindTheWorldContext.SaveChangesAsync();

            return null;
        }

        public async Task<IEnumerable<OilConsumption>> ImportOilConsumptions(IFormFile inputFile)
        {
            var dataTable = await _csvTransformer.Transform(inputFile);

            _mindTheWorldContext
                .OilConsumptions
                .AddRange(await _transformService.ToEntities<OilConsumption, decimal?>(dataTable));

            await _mindTheWorldContext.SaveChangesAsync();

            return null;
        }
    }
}
