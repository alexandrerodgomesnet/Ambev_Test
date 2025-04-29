namespace Ambev.DeveloperEvaluation.Common.Results.Extensions;

public static partial class ResultExtensions
{
    public static Result<TIn> Tap<TIn>(this Result<TIn> result, 
        Action<TIn> action) 
    {
        if(result.IsSuccess)
            action(result.Value);
        
        return result;
    }

    public static async Task<Result<T>> Tap<T>(this Task<Result<T>> task, 
        Action<Result<T>> action)
    {
        var result = await task;

        if(result.IsSuccess)
            action(result.Value);

        return result;
    }

    public static Result<TOut> Tap<T, TOut>(this Result<T> result, Action<Result<T>> action)
    {
        if (result.IsSuccess)
            action(result.Value);

        return Result.Failure<TOut>(result.Errors);
    }

    public static async Task<Result<T>> Tap<T>(this Result<T> result, Func<Task> func)
    {
        if(result.IsSuccess)
            await func();

        return result;
    }

    public static Result<TOut> Tap<T, TOut>(this Result<T> result, Func<T, TOut> func)
    {
        if (result.IsSuccess)
            return func(result.Value);
        return Result.Failure<TOut>(result.Errors);
    }

    public static async Task<Result<TOut>> TapAsync<T, TOut>(this Result<T> result, 
        Func<T, Task<Result<TOut>>> func) =>
        result.IsSuccess ?
            await func(result.Value) :
            await Task.FromResult(Result.Failure<TOut>(result.Errors));

    public static async Task<Result<T>> TapAsync<T>(this Task<Result<T>> resultTask, 
        Func<T, Task> func)
    {
        var result = await resultTask;

        if(result.IsSuccess)
            await func(result.Value);

        return result;
    }
}