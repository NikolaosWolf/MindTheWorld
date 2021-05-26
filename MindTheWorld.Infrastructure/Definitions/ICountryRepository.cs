using MindTheWorld.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindTheWorld.Infrastructure.Definitions
{
    public interface ICountryRepository
    {
        /// <summary>
        /// Retrieves all <see cref="Country"/>.
        /// </summary>
        /// <returns></returns>
        Task<ICollection<Country>> GetCountriesAsync();

        /// <summary>
        /// Retrieves a <see cref="Country"/> by ID.
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        Task<Country> GetCountryAsync(int countryId);

        /// <summary>
        /// Retrieves a <see cref="Country"/> by its name.
        /// </summary>
        /// <param name="countryName"></param>
        /// <returns></returns>
        Task<Country> GetCountryByNameAsync(string countryName);

        /// <summary>
        /// Adds a <see cref="Country"/> to the context collection.
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        Task<Country> SaveAsync(Country country);
    }
}
