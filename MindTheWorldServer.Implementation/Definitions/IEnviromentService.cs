using Microsoft.AspNetCore.Http;
using MindTheWorldServer.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindTheWorldServer.Services.Definitions
{
    public interface IEnviromentService
    {
        /// <summary>
        /// Imports a collection of <see cref="MaterialFootprintPerCapitum"/> from a .csv file to the database.
        /// </summary>
        /// <param name="inputFile">The csv file.</param>
        /// <returns></returns>
        Task<IEnumerable<MaterialFootprintPerCapitum>> ImportMaterialFootprints(IFormFile inputFile);

        /// <summary>
        /// Imports a collection of <see cref="Co2EmissionsPerPerson"/> from a .csv file to the database.
        /// </summary>
        /// <param name="inputFile">The csv file.</param>
        /// <returns></returns>
        Task<IEnumerable<Co2EmissionsPerPerson>> ImportCo2Emissions(IFormFile inputFile);

        /// <summary>
        /// Imports a collection of <see cref="EpidemicDeath"/> from a .csv file to the database.
        /// </summary>
        /// <param name="inputFile">The csv file.</param>
        /// <returns></returns>
        Task<IEnumerable<EpidemicDeath>> ImportEpidemicDeaths(IFormFile inputFile);

        /// <summary>
        /// Imports a collection of <see cref="RenewableWater"/> from a .csv file to the database.
        /// </summary>
        /// <param name="inputFile">The csv file.</param>
        /// <returns></returns>
        Task<IEnumerable<RenewableWater>> ImportRenewableWaters(IFormFile inputFile);

        /// <summary>
        /// Imports a collection of <see cref="WaterWithdrawlPerPerson"/> from a .csv file to the database.
        /// </summary>
        /// <param name="inputFile">The csv file.</param>
        /// <returns></returns>
        Task<IEnumerable<WaterWithdrawlPerPerson>> ImportWaterWithdrawals(IFormFile inputFile);
    }
}
