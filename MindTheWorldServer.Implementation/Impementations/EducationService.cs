using Microsoft.AspNetCore.Http;
using MindTheWorldServer.Domain;
using MindTheWorldServer.Extras.Helpers;
using MindTheWorldServer.Services.Definitions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindTheWorldServer.Services.Implementations
{
    public class EducationService : IEducationService
    {
        private readonly ICsvTransformer _csvTransformer;
        private readonly ITransformService _transformService;
        private readonly MindTheWorldContext _mindTheWorldContext;

        public EducationService(ICsvTransformer csvTransformer,
                                ITransformService transformService,
                                MindTheWorldContext mindTheWorldContext)
        {
            _csvTransformer = csvTransformer;
            _transformService = transformService;
            _mindTheWorldContext = mindTheWorldContext;
        }

        public async Task<IEnumerable<LiteracyRateAdultTotal>> ImportAdultLiteracyRates(IFormFile inputFile)
        {
            var dataTable = await _csvTransformer.Transform(inputFile);

            _mindTheWorldContext
                .LiteracyRateAdultTotals
                .AddRange(await _transformService.ToEntities<LiteracyRateAdultTotal, decimal?>(dataTable));

            await _mindTheWorldContext.SaveChangesAsync();

            return null;
        }
    }
}
