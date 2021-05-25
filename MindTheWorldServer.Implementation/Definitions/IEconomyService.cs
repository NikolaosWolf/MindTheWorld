using Microsoft.AspNetCore.Http;
using MindTheWorldServer.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindTheWorldServer.Services.Definitions
{
    public interface IEconomyService
    {
        /// <summary>
        /// Imports a collection of <see cref="GrossDomesticProduct"/> from a .csv file to the database.
        /// </summary>
        /// <param name="inputFile">The csv file.</param>
        /// <returns></returns>
        Task<IEnumerable<GrossDomesticProduct>> ImportGrossDomesticProducts(IFormFile inputFile);
    }
}
