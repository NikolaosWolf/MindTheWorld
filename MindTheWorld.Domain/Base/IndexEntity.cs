namespace MindTheWorld.Domain.Base
{
    public abstract class IndexEntity : IIndexEntity
    {
        public virtual int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual int Year { get; set; }

        public virtual double? Value { get; set; }

        public virtual bool IsTransient => CountryId == default && Year == default;

        public int Lustrum => CalculaterLustrum(Year);

        public int Decade => CalculaterDecade(Year);

        public int TwentyYears => CalculaterTwentyYears(Year);

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != GetType())
                return false;

            return ReferenceEquals(obj, this) || Equals((IIndexEntity)obj);
        }

        protected virtual bool Equals(IIndexEntity entity)
        {
            return !IsTransient
                && !entity.IsTransient
                && CountryId.Equals(entity.CountryId) && Year.Equals(entity.Year);
        }

        public override int GetHashCode()
        {
            return 2108858624 + CountryId.GetHashCode();
        }

        int CalculaterLustrum(int year)
        {
            if (year >= 1900 && year < 2000)
                return (year / 5 * 5) - 1900;

            if(year >= 1800 && year < 1900)
                return (year / 5 * 5) - 1800;

            return year / 5 * 5;
        }

        int CalculaterDecade(int year)
        {
            if (year >= 1900 && year < 2000)
                return (year / 10 * 10) - 1900;

            if (year >= 1800 && year < 1900)
                return (year / 10 * 10) - 1800;

            return year / 10 * 10;
        }

        int CalculaterTwentyYears(int year)
        {
            if (year >= 1900 && year < 2000)
                return (year / 20 * 20) - 1900;

            if (year >= 1800 && year < 1900)
                return (year / 20 * 20) - 1800;

            return year / 20 * 20;
        }
    }
}
