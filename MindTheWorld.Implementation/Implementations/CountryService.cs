using Microsoft.EntityFrameworkCore;
using MindTheWorld.Api.Dtos;
using MindTheWorld.Domain;
using MindTheWorld.Domain.Base;
using MindTheWorld.Infrastructure.Definitions;
using MindTheWorld.Services.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindTheWorld.Services.Implementations
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly MindTheWorldContext _mindTheWorldContext;

        public CountryService(ICountryRepository countryRepository,
                              MindTheWorldContext mindTheWorldContext)
        {
            _countryRepository = countryRepository;
            _mindTheWorldContext = mindTheWorldContext;
        }

        public async Task<IEnumerable<CountryDto>> GetCountriesAsync()
        {
            var countries = await _countryRepository.GetCountriesAsync();

            return countries.Select(c => new CountryDto { Id = c.Id, Name = c.Name });
        }

        public async Task<IEnumerable<PointDto>> GetIndexPointsByCountryAsync(int countryId, string firstIndex, string secondIndex)
        {
            var pointsX = await Factory(countryId, firstIndex);
            if (pointsX == null || !pointsX.Any())
                return Enumerable.Empty<PointDto>();

            var minYearX = pointsX.Select(p => p.Year).Min();
            var maxYearX = pointsX.Select(p => p.Year).Max();

            var pointsY = await Factory(countryId, secondIndex);
            if (pointsY == null || !pointsY.Any())
                return Enumerable.Empty<PointDto>();

            var minYearY = pointsY.Select(p => p.Year).Min();
            var maxYearY = pointsY.Select(p => p.Year).Max();

            var minYear = Math.Min(minYearX, maxYearY);
            var maxYear = Math.Max(maxYearX, maxYearY);

            var points = new List<PointDto>();
            int currentYear = minYear;
            while (currentYear <= maxYear)
            {
                var pointX = pointsX.SingleOrDefault(p => p.Year == currentYear);
                var pointY = pointsY.SingleOrDefault(p => p.Year == currentYear);
                points.Add(new PointDto
                {
                    X = pointX != null ? pointX.Value : default(double),
                    Y = pointY != null ? pointY.Value : default(double),
                });

                currentYear++;
            }

            return points;
        }

        private async Task<IEnumerable<YearlyValue>> Factory(int countryId, string index)
        {
            if (index.Equals("Co2Emissions", System.StringComparison.InvariantCultureIgnoreCase))
                return await ConvertToPoints<Co2EmissionsPerPerson>(countryId);

            if (index.Equals("CoalConsumption", System.StringComparison.InvariantCultureIgnoreCase))
                return await ConvertToPoints<CoalConsumption>(countryId);

            if (index.Equals("EpidemicDeaths", System.StringComparison.InvariantCultureIgnoreCase))
                return await ConvertToPoints<EpidemicDeath>(countryId);

            if (index.Equals("GrossDomesticProduct", System.StringComparison.InvariantCultureIgnoreCase))
                return await ConvertToPoints<GrossDomesticProduct>(countryId);

            if (index.Equals("HappinessScore", System.StringComparison.InvariantCultureIgnoreCase))
                return await ConvertToPoints<HappinessScore>(countryId);

            if (index.Equals("HumanDevelopmentIndex", System.StringComparison.InvariantCultureIgnoreCase))
                return await ConvertToPoints<HumanDevelopmentIndex>(countryId);

            if (index.Equals("InfantMortalities", System.StringComparison.InvariantCultureIgnoreCase))
                return await ConvertToPoints<InfantMortality>(countryId);

            if (index.Equals("LiiteracyRateForAdults", System.StringComparison.InvariantCultureIgnoreCase))
                return await ConvertToPoints<LiteracyRateAdultTotal>(countryId);

            if (index.Equals("MaterialFootprint", System.StringComparison.InvariantCultureIgnoreCase))
                return await ConvertToPoints<MaterialFootprintPerCapitum>(countryId);

            if (index.Equals("OilConsumption", System.StringComparison.InvariantCultureIgnoreCase))
                return await ConvertToPoints<OilConsumption>(countryId);

            if (index.Equals("Population", System.StringComparison.InvariantCultureIgnoreCase))
                return await ConvertToPoints<Population>(countryId);

            if (index.Equals("RenewableWater", System.StringComparison.InvariantCultureIgnoreCase))
                return await ConvertToPoints<RenewableWater>(countryId);

            if (index.Equals("ResidentialElectricityUse", System.StringComparison.InvariantCultureIgnoreCase))
                return await ConvertToPoints<ResidentialElectricityUse>(countryId);

            if (index.Equals("WaterSourceAccess", System.StringComparison.InvariantCultureIgnoreCase))
                return await ConvertToPoints<WaterSourceAccess>(countryId);

            if (index.Equals("WaterWithdrawalPerPerson", System.StringComparison.InvariantCultureIgnoreCase))
                return await ConvertToPoints<WaterWithdrawlPerPerson>(countryId);

            return null;
        }

        private async Task<IEnumerable<YearlyValue>> ConvertToPoints<T>(int countryId)
            where T : IndexEntity
        {
            var entities = await _mindTheWorldContext.Set<T>().Where(e => e.CountryId == countryId).ToListAsync();

            return entities.Select(e => new YearlyValue { Year = e.Year, Value = e.Value.GetValueOrDefault() });
        }
    }
}
