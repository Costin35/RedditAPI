using RedditAPI.Services.Constants;

namespace RedditAPI.Services;

public class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    public Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None ||
            !isSuccess && error == Error.None)
            throw new ArgumentException("Invalid error", nameof(error));

        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new(true, Error.None);
    public static Result Failure(Error error) => new(false, error);

    public TResult Match<TResult>(Func<TResult> onSuccess, Func<Error, TResult> onFailure)
    {
        if (IsSuccess)
        {
            return onSuccess();
        }
        else
        {
            return onFailure(Error);
        }
    }
}

public class Result<T> : Result
{
    public T Value { get; }

    public Result(T value, bool isSuccess, Error error) : base(isSuccess, error)
    {
        Value = value;
    }
    public static Result<T> Success(T value) => new(value, true, Error.None);
    public static new Result<T> Failure(Error error) => new(default, false, error);

    public TResult Match<TResult>(Func<T, TResult> onSuccess, Func<Error, TResult> onFailure)
    {
        if (IsSuccess)
        {
            return onSuccess(Value);
        }
        else
        {
            return onFailure(Error);
        }
    }
    
}