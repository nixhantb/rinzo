

using Rinzo.Domain.Primitives;
using Rinzo.Domain.Shared;

namespace Rinzo.Domain.ValueObjects
{
    public class FirstName : ValueObject
    {
        public string Value { get; }
        public FirstName(string value)
        {
            Value = value;
        }

        public static Result<FirstName> Create(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                return Result.Failure<FirstName>(new Error("FirstName.Empty", "FirstName is Empty"));
            }
            if(firstName.Length > 50)
            {
                return Result.Failure<FirstName>(new Error("FirstName.NameTooLong", "FirstName is too long"));
            }
            return new FirstName(firstName);
        }
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
