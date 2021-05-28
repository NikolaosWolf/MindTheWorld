using MindTheWorld.Domain.Enums;
using MindTheWorld.Services.Definitions;
using System;
using System.Collections.Generic;

namespace MindTheWorld.Services.Implementations
{
    public class CommonService : ICommonService
    {
        public IEnumerable<string> GetIndexTypes()
        {
            return Enum.GetNames(typeof(IndexType));
        }


    }
}
