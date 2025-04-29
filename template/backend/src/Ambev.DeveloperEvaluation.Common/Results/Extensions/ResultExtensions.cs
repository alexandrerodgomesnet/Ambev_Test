namespace Ambev.DeveloperEvaluation.Common.Results.Extensions;

public static partial class ResultExtensions
{
    public static Result<TOut> TryCatch<TIn, TOut>(this Result<TIn> result, 
        Func<TIn, TOut> func, Error error) 
    {
        try
        {
            return result.IsSuccess ? 
                Result.Success(func(result.Value)) : 
                Result.Failure<TOut>(result.Errors);
        }
        catch 
        {
            return Result.Failure<TOut>(error);
        }
    }

    public static async Task<Result<TOut>> TryCatchAsync<TIn, TOut>(this Result<TIn> result,
        Func<TIn, Task<TOut>> func, string message)
    {
        try
        {
            if(result.IsSuccess)
            {
                var res = await func(result.Value);
                return Result.Success(res);
            }
            return Result.Failure<TOut>(result.Errors);
        }
        catch(Exception ex)
        {
            var messageError = $"{message} Error: {ex.Message}";
            return Result.Failure<TOut>(Error.Exception(messageError));
        }
    }



    public static Result<T> Ensure<T>(this Result<T> result, 
        Func<T, bool> predicate, Error error) =>
        result.IsFailure ?
            result :
            (predicate(result.Value) ? 
                result : 
                Result.Failure<T>(error));

    public static Result<T> Ensure<T>(this Result<T> result, 
        params (Func<T, bool> predicate, Error error)[] functions)
    {
        var list = new List<Result<T>>();
        foreach (var (predicate, error) in functions)
        {
            list.Add(Ensure(result.Value, predicate, error));
        }

        return Combine(list.ToArray());
    }

    private static Result<T> Ensure<T>(T value, 
        Func<T, bool> predicate, Error error) =>
        predicate(value) ? 
        Result.Success(value) : 
        Result.Failure<T>(error);
    
    private static Result<T> Combine<T>(params Result<T>[] results)
    {
        if(results.Any(r => r.IsFailure))
        {
            return Result.Failure<T>(
                [.. results
                .SelectMany(r => r.Errors)
                .Distinct()]);
        }

        return Result.Success(results[0].Value);
    }

    public static Result<(T1, T2)> Combine<T1, T2>(Result<T1> result1, Result<T2> result2)
    {
        if(result1.IsFailure)
            return (Result<(T1, T2)>)Result.Failure(result1.Errors);

        if(result2.IsFailure)
            return (Result<(T1, T2)>)Result.Failure(result2.Errors);

        return Result.Success((result1.Value, result2.Value));
    }
}