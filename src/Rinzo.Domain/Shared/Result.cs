
namespace Rinzo.Domain.Shared
{
    public class Result
    {
        protected internal Result(bool isSuccess, string error)
        {
            if(isSuccess && error !=Error.None)
            {
                throw new InvalidOperationException("Success cannot have an error message.");
            }
            if(!isSuccess && error == Error.None)
            {
                throw new InvalidOperationException("Failure must have an error message.");
            }

            IsSuccess = isSuccess;
            Error = error;


        }

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }

        public static Result Success() => new(true, Error.None);

        public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

        public static Result Failure(Error error) => new(false, error);

        public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);

        public static Result<TValue> Create<TValue>(TValue? value) => value is not null ? Success(value) : Failure<TValue>(Error.NullValue);

    }
}
