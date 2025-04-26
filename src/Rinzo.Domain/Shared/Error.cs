namespace Rinzo.Domain.Shared
{
    public class Error : IEquatable<Error>
    {
        public static readonly Error None = new (string.Empty, string.Empty);
        public static readonly Error NullValue = new("Error.Nullvalue", "The specified result value is null.");
        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public string Code { get; }
        public string Message { get; }

        public static implicit operator string(Error error)
        {
            return error.Code;
        }
        public static implicit operator Error(string code)
        {
            return new Error(code, string.Empty);
        }
        // Error comparision  Type-specific equality
        public virtual bool Equals(Error? other)
        {
            if(other is null)
            {
                return false;
            }
            return Code == other.Code && Message == other.Message;
        }

        // Error comparison  : Reference + Values
        // error1 == error2 ➔ true if object values match 
        

        public static bool operator ==(Error? left, Error? right)
        {
            if (left is null && right is null)
            {
                return true;
            }
            if (left is null || right is null)
            {
                return false;
            }
            return left.Equals(right);
        }

        public static bool operator !=(Error? left, Error? right)
        {
            return !(left == right);
        }

        // Object comparison General object equality (required by .NET)
        public override bool Equals(object? obj)
        {
            if (obj is Error error)
            {
                return Equals(error);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Code, Message);
        }

        public override string ToString() => Code;

    }
}
