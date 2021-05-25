using Microsoft.AspNetCore.Http;
using MindTheWorldServer.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindTheWorldServer.Services.Definitions
{
    public interface IHealthService
    {
        /// <summary>
        /// Imports a collection of <see cref="InfantMortality"/> from a .csv file to the database.
        /// </summary>
        /// <param name="inputFile">The csv file.</param>
        /// <returns></returns>
        Task<IEnumerable<InfantMortality>> ImportInfantMortalities(IFormFile inputFile);
    }
}
