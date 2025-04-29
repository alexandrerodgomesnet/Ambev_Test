using System.Diagnostics.CodeAnalysis;

namespace Ambev.DeveloperEvaluation.Common.Results;

public class Result<T> : Result
{
    private readonly T? _value;
    public Result(T? value, bool isSuccess, Error? error) 
        : base(isSuccess, error)
    {
        _value = value;
    }

    public Result(T? value, bool isSuccess, Error[] errors) 
        : base(isSuccess, errors)
    {
        _value = value;
    }

    [NotNull]
    public T Value => IsSuccess 
        ? _value! 
        : throw new InvalidOperationException("The value of a failure resut can't be accessed.");

    public static implicit operator Result<T>(T? value) =>
        value is not null ? 
            Success(value) : 
            Failure<T>(Error.NullValue);
    public static Result<T> ValidationFailure(Error error) =>
        new (default, false, error);
    public static Result<T> Failure(Exception exception) =>
        new (default, false, Error.Exception(exception.Message));
}