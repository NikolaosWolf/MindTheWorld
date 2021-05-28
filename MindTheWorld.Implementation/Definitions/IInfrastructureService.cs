using Microsoft.AspNetCore.Http;
using MindTheWorld.Api.Dtos;
using MindTheWorld.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindTheWorld.Services.Definitions
{
    public interface IInfrastructureService
    {
        Task<IEnumerable<IndexDto>> GetWaterSourceAccessesAsync();

        /// <summary>
        /// Imports a collection of <see cref="WaterSourceAccess"/> from a .csv file to the database.
        /// </summary>
        /// <param name="inputFile">The csv file.</param>
        /// <returns></returns>
        Task<IEnumerable<WaterSourceAccess>> ImportWaterSourceAccesses(IFormFile inputFile);
    }
}
