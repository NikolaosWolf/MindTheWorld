using Microsoft.AspNetCore.Http;
using System.Data;
using System.Threading.Tasks;

namespace MindTheWorld.Extras.Helpers
{
    public interface ICsvTransformer
    {
        /// <summary>
        /// Transforms a CSV file to a Dictionary.
        /// </summary>
        /// <param name="csvFile">The CSV file.</param>
        /// <returns></returns>
        Task<DataTable> Transform(IFormFile csvFile);
    }
}
