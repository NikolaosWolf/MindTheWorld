using Microsoft.AspNetCore.Http;
using MindTheWorldServer.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindTheWorldServer.Services.Definitions
{
    public interface IInfrastructureService
    {
        /// <summary>
        /// Imports a collection of <see cref="WaterSourceAccess"/> from a .csv file to the database.
        /// </summary>
        /// <param name="inputFile">The csv file.</param>
        /// <returns></returns>
        Task<IEnumerable<WaterSourceAccess>> ImportWaterSourceAccesses(IFormFile inputFile);
    }
}
