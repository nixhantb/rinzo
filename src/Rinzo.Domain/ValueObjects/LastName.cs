

using Rinzo.Domain.Primitives;
using Rinzo.Domain.Shared;

namespace Rinzo.Domain.ValueObjects
{
    public class LastName : ValueObject
    {
        public string Value { get; }
        public LastName(string value)
        {
            Value = value;
        }

        public static Result<LastName> Create(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                return Result.Failure<LastName>(new Error("LastName.Empty", "LastName is Empty"));
            }
            if (lastName.Length > 50)
            {
                return Result.Failure<LastName>(new Error("LastName.NameTooLong", "LastName is too long"));
            }
            return new LastName(lastName);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
