namespace Ambev.DeveloperEvaluation.Common.Results.Extensions;

public static partial class ResultExtensions
{
    public static Result<TOut> Bind<TOut>(this Result result, Func<Result<TOut>> func)
        => result.IsSuccess
            ? func()
            : Result.Failure<TOut>(result.Errors);

    public static Result Bind<TIn>(this Result<TIn> result, Func<TIn, Result> func)
        => result.IsSuccess
            ? func(result.Value)
            : result;

    public static Result Bind(this Result result, Func<Result> func)
        => result.IsSuccess
            ? func()
            : result;

    public static Result<TOut> Bind<TIn, TOut>(this Result<TIn> result, Func<TIn, Result<TOut>> func)
        => result.IsSuccess
            ? func(result.Value)
            : Result.Failure<TOut>(result.Errors);

    public static async Task<Result<TOut>> BindAsync<TIn, TOut>(
        this Task<Result<TIn>> result,
        Func<TIn, Result<TOut>> bind)
    {
        var res = await result;
        return res.IsSuccess
            ? bind(res.Value)
            : Result.Failure<TOut>(res.Errors);
    }
}