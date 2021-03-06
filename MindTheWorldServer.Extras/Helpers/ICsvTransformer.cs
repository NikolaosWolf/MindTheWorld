using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindTheWorldServer.Extras.Helpers
{
    public interface ICsvTransformer
    {
        /// <summary>
        /// Transforms a CSV file to a Dictionary.
        /// </summary>
        /// <param name="csvFile">The CSV file.</param>
        /// <returns></returns>
        Task<Dictionary<string, IEnumerable<string>>> Transform(IFormFile csvFile);
    }
}
