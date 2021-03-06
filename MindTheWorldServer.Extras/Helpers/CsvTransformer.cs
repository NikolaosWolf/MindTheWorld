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

                    string key = lineAsList[0];
                    lineAsList.RemoveAt(0);

                    result.Add(key, lineAsList);
                }
            }

            return result;
        }
    }
}
