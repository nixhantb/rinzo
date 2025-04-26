
namespace Rinzo.Domain.Primitives
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        public abstract IEnumerable<object> GetAtomicValues();

        private bool ValuesAreEqual(ValueObject other)
        {
            if(other is null)
            {
                return false;
            }
            return GetAtomicValues().SequenceEqual(other.GetAtomicValues());
        }
        public override bool Equals(object? obj)
        {
           if(obj is ValueObject other)
            {
                return GetAtomicValues().SequenceEqual(other.GetAtomicValues());
            }
            return false;
        }
        public override int GetHashCode()
        {
            return GetAtomicValues()
                .Select(x => x?.GetHashCode() ?? 0)
                .Aggregate((x, y) => x ^ y);
        }

        public bool Equals(ValueObject? other)
        {
            return other is not null && ValuesAreEqual(other);
        }
    }
}
