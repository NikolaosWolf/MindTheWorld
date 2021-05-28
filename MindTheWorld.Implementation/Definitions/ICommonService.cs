using MindTheWorld.Domain.Enums;
using System.Collections.Generic;

namespace MindTheWorld.Services.Definitions
{
    public interface ICommonService
    {
        /// <summary>
        /// Retrieves all index types of the application. Found in <see cref="IndexType"/>.
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetIndexTypes();
    }
}
