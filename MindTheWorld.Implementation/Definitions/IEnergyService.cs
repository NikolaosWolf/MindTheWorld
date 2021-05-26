using Microsoft.AspNetCore.Http;
using MindTheWorld.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindTheWorld.Services.Definitions
{
    public interface IEnergyService
    {
        /// <summary>
        /// Imports a collection of <see cref="ResidentialElectricityUse"/> from a .csv file to the database.
        /// </summary>
        /// <param name="inputFile">The csv file.</param>
        /// <returns></returns>
        Task<IEnumerable<ResidentialElectricityUse>> ImportResidentialElectricityUses(IFormFile inputFile);

        /// <summary>
        /// Imports a collection of <see cref="CoalConsumption"/> from a .csv file to the database.
        /// </summary>
        /// <param name="inputFile">The csv file.</param>
        /// <returns></returns>
        Task<IEnumerable<CoalConsumption>> ImportCoalConsumptions(IFormFile inputFile);

        /// <summary>
        /// Imports a collection of <see cref="CoalConsumption"/> from a .csv file to the database.
        /// </summary>
        /// <param name="inputFile">The csv file.</param>
        /// <returns></returns>
        Task<IEnumerable<OilConsumption>> ImportOilConsumptions(IFormFile inputFile);
    }
}
