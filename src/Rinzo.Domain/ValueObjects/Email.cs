

using Rinzo.Domain.Primitives;
using Rinzo.Domain.Shared;
namespace Rinzo.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string Value { get; }
        public Email(string value)
        {
            Value = value;
        }
        public static Result<Email> Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return Result.Failure<Email>(new Error("Email.Empty", "Email is Empty"));
            }
            if (email.Length > 100)
            {
                return Result.Failure<Email>(new Error("Email.NameTooLong", "Email is too long"));
            }
            if (!email.Contains("@") || !email.Contains("."))
            {
                return Result.Failure<Email>(new Error("Email.InvalidFormat", "Email format is invalid"));
            }
            return new Email(email);
        }
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
    {
    }
}
