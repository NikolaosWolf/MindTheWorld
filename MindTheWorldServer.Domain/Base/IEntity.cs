namespace MindTheWorldServer.Domain.Base
{
    /// <summary>
    /// The basic contract for the Entities.
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public interface IEntity<TId>
    {
        /// <summary>
        /// The primary identifier for Entities.
        /// </summary>
        TId Id { get; set; }

        /// <summary>
        /// Returns <c>True</c> if the entity is in transient state.
        /// </summary>
        bool IsTransient { get; }
    }
}
