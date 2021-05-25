using MindTheWorldServer.Domain.Base;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MindTheWorldServer.Services.Definitions
{
    public interface ITransformService
    {
        /// <summary>
        /// Generic importer for indexes.
        /// </summary>
        /// <typeparam name="TIndex">Index Type</typeparam>
        /// <param name="dataTable">Contains the index information</param>
        /// <returns></returns>
        Task<IEnumerable<TIndex>> ToEntities<TIndex, TValue>(DataTable dataTable)
            where TIndex : IIndexEntity<TValue>, new();
    }
}
