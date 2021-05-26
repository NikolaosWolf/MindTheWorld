namespace MindTheWorld.Domain.Base
{
    /// <summary>
    /// This is the Base Entity Object. All entities must inherit from this.
    /// </summary>
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        /// <summary>
        /// Entity Identifier
        /// </summary>
        public virtual TKey Id { get; set; }

        /// <inheritdoc cref="IEntity{TId}.IsTransient"/>
        public abstract bool IsTransient { get; }

        /// <summary>
        /// Equality comparer.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != GetType())
                return false;

            return ReferenceEquals(obj, this) || Equals((IEntity<TKey>)obj);
        }

        /// <summary>
        /// Equality comparer
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected virtual bool Equals(IEntity<TKey> entity)
        {
            return !IsTransient
                && !entity.IsTransient
                && Id.Equals(entity.Id);
        }

        /// <summary>
        /// Override of GetHashCode()
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
    }
}
