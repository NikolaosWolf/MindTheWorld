using Microsoft.AspNetCore.Http;
using MindTheWorld.Domain;
using MindTheWorld.Extras.Helpers;
using MindTheWorld.Services.Definitions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindTheWorld.Services.Implementations
{
    public class PopulationService : IPopulationService
    {
        private readonly ICsvTransformer _csvTransformer;
        private readonly ITransformService _transformService;
        private readonly MindTheWorldContext _mindTheWorldContext;

        public PopulationService(ICsvTransformer csvTransformer,
                              ITransformService transformService,
                              MindTheWorldContext mindTheWorldContext)
        {
            _csvTransformer = csvTransformer;
            _transformService = transformService;
            _mindTheWorldContext = mindTheWorldContext;
        }

        public async Task<IEnumerable<Population>> ImportPopulations(IFormFile inputFile)
        {
            var dataTable = await _csvTransformer.Transform(inputFile);

            _mindTheWorldContext
                .Populations
                .AddRange(await _transformService.ToEntities<Population, int?>(dataTable));

            await _mindTheWorldContext.SaveChangesAsync();

            return null;
        }
    }
}
