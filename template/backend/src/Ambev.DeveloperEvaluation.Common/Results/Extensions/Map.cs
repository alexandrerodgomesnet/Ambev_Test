namespace Ambev.DeveloperEvaluation.Common.Results.Extensions;
public static partial class ResultExtensions
{
    public static Result<TOut> Map<TIn, TOut>(this Result<TIn> result, Func<TIn, TOut> func)
        => result.IsSuccess
            ? Result.Success(func(result.Value))
            : Result.Failure<TOut>(result.Errors);

    public static Result<TOut> Map<TOut>(this Result result, Func<TOut> func)
        => result.IsSuccess
            ? Result.Success(func())
            : Result.Failure<TOut>(result.Errors);

    public static Result<TOut> Map<TIn, TOut>(this Task<Result<TIn>> result,
        Func<TIn, TOut> mappingFunc)
    {
        var res = result.Result;

        if (res.IsSuccess)
            return Result.Success(mappingFunc(res.Value));

        return Result.Failure<TOut>(res.Errors);
    }

    public static async Task<Result<TOut>> MapAsync<TIn, TOut>(this Task<Result<TIn>> result,
        Func<TIn, TOut> func)
    {
        var res = result.Result;

        if (res.IsSuccess)
            return await Task.FromResult(Result.Success(func(res.Value)));

        return await Task.FromResult(Result.Failure<TOut>(res.Errors));
    }
}