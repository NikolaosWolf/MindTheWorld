using Microsoft.AspNetCore.Http;
using MindTheWorldServer.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindTheWorldServer.Services.Definitions
{
    public interface IPopulationService
    {
        /// <summary>
        /// Imports a collection of <see cref="Population"/> from a .csv file to the database.
        /// </summary>
        /// <param name="inputFile">The csv file.</param>
        /// <returns></returns>
        Task<IEnumerable<Population>> ImportPopulations(IFormFile inputFile);
    }
}
