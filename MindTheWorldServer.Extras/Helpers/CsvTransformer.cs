using GenericParsing;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace MindTheWorldServer.Extras.Helpers
{
    public class CsvTransformer : ICsvTransformer
    {
        public CsvTransformer()
        {
        }

        public async Task<DataTable> Transform(IFormFile file)
        {
            var dataTable = new DataTable();

            using (var parser = new GenericParser(new StreamReader(file.OpenReadStream())))
            {
                await LoadHeader(parser, dataTable);
                await LoadData(parser, dataTable);
            };

            return dataTable;
        }

        private async Task LoadHeader(GenericParser parser, DataTable dataTable)
        {
            parser.Read();

            for (int i = 0; i < parser.ColumnCount; i++)
                dataTable.Columns.Add(parser[i]);
        }

        private async Task LoadData(GenericParser parser, DataTable dataTable)
        {
            while (parser.Read())
            {
                DataRow row = dataTable.NewRow();

                for (int i = 0; i < dataTable.Columns.Count; i++)
                    row[i] = parser[i];

                dataTable.Rows.Add(row);
            }
        }
    }
}
