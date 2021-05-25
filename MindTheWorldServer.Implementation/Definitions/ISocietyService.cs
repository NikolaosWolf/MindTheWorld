using Microsoft.AspNetCore.Http;
using MindTheWorldServer.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindTheWorldServer.Services.Definitions
{
    public interface ISocietyService
    {
        /// <summary>
        /// Imports a collection of <see cref="HappinessScore"/> from a .csv file to the database.
        /// </summary>
        /// <param name="inputFile">The csv file.</param>
        /// <returns></returns>
        Task<IEnumerable<HappinessScore>> ImportHappinessScores(IFormFile inputFile);

        /// <summary>
        /// Imports a collection of <see cref="HumanDevelopmentIndex"/> from a .csv file to the database.
        /// </summary>
        /// <param name="inputFile">The csv file.</param>
        /// <returns></returns>
        Task<IEnumerable<HumanDevelopmentIndex>> ImportHumanDevelopmentIndexes(IFormFile inputFile);
    }
}
