namespace TikRandevu.Shared.Domain.ResponseFoundation;

public class Result<T> : Result
{
    private readonly T _value;


    public Result(bool isSuccess, Error error, T? value) : base(isSuccess, error)
    {
        _value = value;
    }

    public T Value =>
        IsSuccess ? _value : throw new InvalidOperationException("Failure Result's value cannot be accessed");

    public static Result<T> Success<T>(T? value)
        => new(true, Error.None, value);

    public static Result<T> Failure<T>(Error error)
        => new(false, error, default);


    public static implicit operator Result<T>(T? value) =>
        value is not null ? Success(value) : Failure<T>(Error.NullValue);

    public static Result<T> ValidationResult(Error error)
        => new(false, error, default);
}

public class Result
{
    public bool IsSuccess { get; private set; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; private set; }

    public Result(bool isSuccess, Error error)
    {
        if (
            isSuccess && error != Error.None ||
            !isSuccess && error == Error.None
        )
        {
            throw new ArgumentException($"Invalid Result Construction with error: {error.ErrorType}");
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success()
        => new(true, Error.None);

    public static Result Failure(Error error)
        => new(false, error);
}