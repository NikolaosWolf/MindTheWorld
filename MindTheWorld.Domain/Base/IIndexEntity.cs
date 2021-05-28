namespace MindTheWorld.Domain.Base
{
    /// <summary>
    /// The basic contract for the Index Entities.
    /// </summary>
    public interface IIndexEntity
    {
        /// <summary>
        /// The index 's Country
        /// </summary>
        int CountryId { get; set; }

        /// <summary>
        /// The index 's Year
        /// </summary>
        int Year { get; set; }

        /// <summary>
        /// The index 's value
        /// </summary>
        double? Value { get; set; }

        /// <summary>
        /// The index 's Country
        /// </summary>
        Country Country { get; set; }

        /// <summary>
        /// Returns <c>True</c> if the entity is in transient state.
        /// </summary>
        bool IsTransient { get; }

        /// <summary>
        /// Returns in which five-year term this year belongs
        /// </summary>
        int Lustrum { get; }

        /// <summary>
        /// Returns in which decade this year belongs
        /// </summary>
        int Decade { get; }

        /// <summary>
        /// Returns in which twenty year term this year belongs
        /// </summary>
        int TwentyYears { get; }
    }
}
