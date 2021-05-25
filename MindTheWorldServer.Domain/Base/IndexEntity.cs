namespace MindTheWorldServer.Domain.Base
{
    public abstract class IndexEntity<TValue> : IIndexEntity<TValue>
    {
        public virtual int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual int Year { get; set; }

        public virtual TValue Value { get; set; }

        public virtual bool IsTransient => CountryId == default && Year == default;

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != GetType())
                return false;

            return ReferenceEquals(obj, this) || Equals((IIndexEntity<TValue>)obj);
        }

        protected virtual bool Equals(IIndexEntity<TValue> entity)
        {
            return !IsTransient
                && !entity.IsTransient
                && CountryId.Equals(entity.CountryId) && Year.Equals(entity.Year);
        }

        public override int GetHashCode()
        {
            return 2108858624 + CountryId.GetHashCode();
        }
    }
}
