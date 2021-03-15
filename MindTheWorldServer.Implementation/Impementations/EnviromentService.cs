using Microsoft.AspNetCore.Http;
using MindTheWorldServer.Api.Dtos;
using MindTheWorldServer.Extras.Helpers;
using MindTheWorldServer.Services.Definitions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindTheWorldServer.Services.Implementations
{
    public class EnviromentService : IEnviromentService
    {
        private readonly ICsvTransformer _csvTransformer;

        public EnviromentService(ICsvTransformer csvTransformer)
        {
            _csvTransformer = csvTransformer;
        }

        public async Task<IEnumerable<Co2EmissionDto>> ImportCo2Emissions(IFormFile inputFile)
        {
            var dictionary = await _csvTransformer.Transform(inputFile);

            var result = new List<Co2EmissionDto>();

            var years = new List<int>();

            var indexRow = dictionary.Values.FirstOrDefault();

            foreach (var year in indexRow)
                years.Add(int.Parse(year));

            years.OrderBy(y => y);

            foreach (var item in dictionary.Skip(1))
            {
                var yearValues = new List<YearlyValueDto>();
                for (int i = 0; i < item.Value.Count(); i++)
                    yearValues.Add(new YearlyValueDto { Year = years[i] , Value = item.Value.ToArray()[i] });

                var emission = new Co2EmissionDto { Country = new CountryDto { Name = item.Key }, YearValues = yearValues }; ;
                result.Add(emission);
            }

            return result;
        }
    }
}
