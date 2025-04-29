namespace Ambev.DeveloperEvaluation.Common.Results;

public class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error[] Errors { get; }

    protected internal Result(bool isSuccess, Error[] errors)
    {
        IsSuccess = isSuccess;
        Errors = errors;
    }

    protected internal Result(bool isSuccess, Error? error)
    {
        if(isSuccess && error != Error.None ||
            !isSuccess && error == Error.None)
            throw new InvalidOperationException("You cannot use an error when the result is successful.");

        IsSuccess = isSuccess;
        Errors = [error!];
    }    

    public static Result Success() => new (true, Error.None);
    public static Result<T> Success<T>(T value) => new (value, true, Error.None);
    public static Result Failure(Error error) => new (false, error);
    public static Result<T> Failure<T>(Error error) => new (default, false, error);
    public static Result Failure(params Error[] errors)
    {
        var validErrors = errors.Where(e => e is not null).ToList();
        if (validErrors.Count == 0)
            validErrors.Add(Error.FailCreated);

        return new(false, [.. validErrors]);
    }

    public static Result<T> Failure<T>(params Error[] errors)
    {
        var validErrors = errors.Where(e => e is not null).ToList();
        if (validErrors.Count == 0)
            validErrors.Add(Error.FailCreated);

        return new(default, false, [.. validErrors]);
    }

    public static Result<T> Create<T>(T? value) =>
        value is not null
            ? Success(value)
            : Failure<T>(Error.NullValue);

    public static implicit operator Result(Error error) => Failure(error);
    public static implicit operator Result(List<Error> errors) => Failure([.. errors]);
}