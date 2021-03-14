using System.Collections.Generic;

namespace MindTheWorldServer.Api.Dtos
{
    public class Co2EmissionDto
    {
        /// <summary>
        /// The country
        /// </summary>
        public CountryDto Country { get; set; }

        /// <summary>
        /// They yearly value
        /// </summary>
        public IEnumerable<YearlyValueDto> YearValues { get; set; }
    }
}
