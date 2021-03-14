using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MindTheWorldServer.Extras.Helpers
{
    public class CsvTransformer : ICsvTransformer
    {
        public CsvTransformer()
        {
        }

        public async Task<Dictionary<string, IEnumerable<string>>> Transform(IFormFile file)
        {
            var result = new Dictionary<string, IEnumerable<string>>();
            
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                {
                    string line = await reader.ReadLineAsync();
                    var lineAsList = line.Split(',').ToList();

                    result.Add(lineAsList[0], lineAsList.Skip(1));
                }
            }

            return result;
        }
    }
}
