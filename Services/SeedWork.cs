using RedditAPI.Services.Constants;

namespace RedditAPI.Services;

public class Result
{
    public bool IsSucces { get; }
    public bool IsFailure => !IsSucces;
    public Error Error { get; }

    public Result(bool isSucces, Error error)
    {
        if (isSucces && error != Error.None ||
            !isSucces && error == Error.None)
            throw new ArgumentException("Invalid error", nameof(error));

        IsSucces = isSucces;
        Error = error;
    }

    public static Result Success() => new(true, Error.None);
    public static Result Failure(Error error) => new(false, error);
}