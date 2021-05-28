using MindTheWorld.Domain;
using MindTheWorld.Domain.Base;
using MindTheWorld.Infrastructure.Definitions;
using MindTheWorld.Services.Definitions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MindTheWorld.Services.Implementations
{
    public class TransformService : ITransformService
    {
        private readonly ICountryRepository _countryRepository;

        public TransformService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<IEnumerable<TIndex>> ToEntities<TIndex>(DataTable dataTable)
            where TIndex : IIndexEntity, new()
        {

            ICollection<Country> countries = await _countryRepository.GetCountriesAsync();

            return await CreateIndexes<TIndex>(dataTable, countries);
        }

        private async Task<IEnumerable<TIndex>> CreateIndexes<TIndex>(DataTable dataTable, ICollection<Country> countries)
            where TIndex : IIndexEntity, new()
        {
            var indexes = new List<TIndex>();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string countryName = dataTable.Rows[i][0].ToString();
                Country country = await ParseCountry(countries, countryName);

                for (int j = 1; j < dataTable.Columns.Count; j++)
                {
                    int year = int.Parse(dataTable.Columns[j].ColumnName);
                    string value = dataTable.Rows[i][j].ToString();

                    var index = new TIndex
                    {
                        Country = country,
                        Year = year,
                        Value = await ParseValue(value)
                    };
                    
                    indexes.Add(index);
                }
            }

            return indexes;
        }

        private async Task<Country> ParseCountry(ICollection<Country> countries, string countryName)
        {
            var country = countries.SingleOrDefault(c => c.Name.Equals(countryName, StringComparison.InvariantCultureIgnoreCase));
            if (country == null)
            {
                var newCountry = new Country { Name = countryName };
                countries.Add(newCountry);
                return newCountry;
            }

            return country;
        }

        private async Task<double?> ParseValue(string value)
        {
                return string.IsNullOrEmpty(value) ? default(double) : (double)Convert.ChangeType(value, typeof(double));
        }
    }
}
