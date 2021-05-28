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

        public async Task<IEnumerable<IndexDto>> GetAdultLiteracyRatesAsync()
        {
            var data = await _mindTheWorldContext.LiteracyRateAdultTotals.Include(d => d.Country).ToListAsync();

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

        public async Task<IEnumerable<LiteracyRateAdultTotal>> ImportAdultLiteracyRates(IFormFile inputFile)
        {
            var dataTable = await _csvTransformer.Transform(inputFile);

            _mindTheWorldContext
                .LiteracyRateAdultTotals
                .AddRange(await _transformService.ToEntities<LiteracyRateAdultTotal>(dataTable));

            await _mindTheWorldContext.SaveChangesAsync();

            return null;
        }
    }
}
