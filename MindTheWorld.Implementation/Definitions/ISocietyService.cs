using Microsoft.AspNetCore.Http;
using MindTheWorld.Api.Dtos;
using MindTheWorld.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindTheWorld.Services.Definitions
{
    public interface ISocietyService
    {
        Task<IEnumerable<IndexDto>> GetHappinessScoresAsync();

        Task<IEnumerable<IndexDto>> GetHumanDevelopmentIndexesAsync();

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
