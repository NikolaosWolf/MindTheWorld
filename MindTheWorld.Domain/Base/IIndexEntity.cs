namespace MindTheWorld.Domain.Base
{
    /// <summary>
    /// The basic contract for the Index Entities.
    /// </summary>
    public interface IIndexEntity<TValue>
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
        TValue Value { get; set; }

        /// <summary>
        /// The index 's Country
        /// </summary>
        Country Country { get; set; }

        /// <summary>
        /// Returns <c>True</c> if the entity is in transient state.
        /// </summary>
        bool IsTransient { get; }
    }
}
