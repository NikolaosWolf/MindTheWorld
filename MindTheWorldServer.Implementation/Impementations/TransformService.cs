using MindTheWorldServer.Domain;
using MindTheWorldServer.Domain.Base;
using MindTheWorldServer.Infrastructure.Definitions;
using MindTheWorldServer.Services.Definitions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MindTheWorldServer.Services.Implementations
{
    public class TransformService : ITransformService
    {
        private readonly ICountryRepository _countryRepository;

        public TransformService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<IEnumerable<TIndex>> ToEntities<TIndex, TValue>(DataTable dataTable)
            where TIndex : IIndexEntity<TValue>, new()
        {

            ICollection<Country> countries = await _countryRepository.GetCountriesAsync();

            return await CreateIndexes<TIndex, TValue>(dataTable, countries);
        }

        private async Task<IEnumerable<TIndex>> CreateIndexes<TIndex, TValue>(DataTable dataTable, ICollection<Country> countries)
            where TIndex : IIndexEntity<TValue>, new()
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
                        Value = await ParseValue<TValue>(value)
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

        private async Task<TValue> ParseValue<TValue>(string value)
        {
            var valueType = typeof(TValue);

            if (valueType == typeof(int) || Nullable.GetUnderlyingType(valueType) == typeof(int))
                return string.IsNullOrEmpty(value) ? default(TValue) : (TValue)Convert.ChangeType(value, typeof(int));

            if (valueType == typeof(long) || Nullable.GetUnderlyingType(valueType) == typeof(long))
                return string.IsNullOrEmpty(value) ? default(TValue) : (TValue)Convert.ChangeType(value, typeof(long));

            if (valueType == typeof(decimal) || Nullable.GetUnderlyingType(valueType) == typeof(decimal))
                return string.IsNullOrEmpty(value) ? default(TValue) : (TValue)Convert.ChangeType(value, typeof(decimal));

            return default(TValue);
        }
    }
}
