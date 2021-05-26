using Microsoft.AspNetCore.Http;
using MindTheWorld.Domain;
using MindTheWorld.Extras.Helpers;
using MindTheWorld.Services.Definitions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindTheWorld.Services.Implementations
{
    public class SocietyService : ISocietyService
    {
        private readonly ICsvTransformer _csvTransformer;
        private readonly ITransformService _transformService;
        private readonly MindTheWorldContext _mindTheWorldContext;

        public SocietyService(ICsvTransformer csvTransformer,
                              ITransformService transformService,
                              MindTheWorldContext mindTheWorldContext)
        {
            _csvTransformer = csvTransformer;
            _transformService = transformService;
            _mindTheWorldContext = mindTheWorldContext;
        }

        public async Task<IEnumerable<HappinessScore>> ImportHappinessScores(IFormFile inputFile)
        {
            var dataTable = await _csvTransformer.Transform(inputFile);

            _mindTheWorldContext
                .HappinessScores
                .AddRange(await _transformService.ToEntities<HappinessScore, decimal?>(dataTable));

            await _mindTheWorldContext.SaveChangesAsync();

            return null;
        }

        public async Task<IEnumerable<HumanDevelopmentIndex>> ImportHumanDevelopmentIndexes(IFormFile inputFile)
        {
            var dataTable = await _csvTransformer.Transform(inputFile);

            _mindTheWorldContext
                .HumanDevelopmentIndexes
                .AddRange(await _transformService.ToEntities<HumanDevelopmentIndex, decimal?>(dataTable));

            await _mindTheWorldContext.SaveChangesAsync();

            return null;
        }
    }
}
