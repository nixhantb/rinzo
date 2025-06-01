

using Rinzo.Domain.Primitives;
using Rinzo.Domain.Shared;
namespace Rinzo.Domain.ValueObjects
{
    public class Phone : ValueObject
    {
        public string Value { get; }
        public Phone(string value)
        {
            Value = value;
        }
        public static Result<Phone> Create(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                return Result.Failure<Phone>(new Error("Phone.Empty", "Phone is Empty"));
            }
            if (phone.Length > 10)
            {
                return Result.Failure<Phone>(new Error("Phone.NameTooLong", "Phone is too long"));
            }
            return new Phone(phone);
        }
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
    
}
