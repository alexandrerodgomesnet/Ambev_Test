namespace Ambev.DeveloperEvaluation.Common.Results.Extensions;

public static partial class ResultExtensions
{
   

    //public static T Match<T>(this Result result, Func<T> onSuccess, Func<string, T> onFailure)
    //    => result.IsSuccess
    //        ? onSuccess()
    //        : onFailure(result.Errors[0].Description);

    // public static void Match<T, E>(this Result<T, E> result, Action<T> onSuccess, Action<E> onFailure)
    //     => result.IsSuccess
    //         ? onSuccess(result.Value)
    //         : onFailure(result.Error);

    //public static void Match<T>(this Result<T> result, Action<T> onSuccess, Action<string> onFailure)
    //{
    //    if(result.IsSuccess)
    //        onSuccess(result.Value);
    //    else
    //        onFailure(result.Errors[0].Description);
    //}

    //public static void Match(this Result result, Action onSuccess, Action<string> onFailure)
    //{
    //    if(result.IsSuccess)
    //       onSuccess();
    //    else
    //        onFailure(result.Errors[0].Description);
    //}

    //public static T Match<T>(this Result result,
    //    Func<T> onSuccess, Func<Result, T> onFailure) =>
    //    result.IsSuccess
    //        ? onSuccess()
    //        : onFailure(result);

    //public static TOut Match<TIn, TOut>(this Result<TIn> result,
    //    Func<TIn, TOut> onSuccess, Func<Result<TIn>, TOut> onFailure) =>
    //    result.IsSuccess
    //        ? onSuccess(result.Value)
    //        : onFailure(result);

    //public static TOut Match<TIn, TOut>(this Result<TIn> result,
    //    Func<TIn, TOut> onSuccess, Func<Error, TOut> onFailure) =>
    //    result.IsSuccess
    //        ? onSuccess(result.Value)
    //        : onFailure(result.Errors[0]);

    //public static TOut Match<TIn, TOut>(this Result<TIn> result,
    //    Func<TIn, TOut> onSuccess, Func<Error[], TOut> onFailure) =>
    //    result.IsSuccess
    //        ? onSuccess(result.Value)
    //        : onFailure(result.Errors);

    public static async Task<TOut> MatchAsync<TIn, TOut>(this Result<TIn> result,
        Func<TIn, TOut> onSuccess, Func<Error[], TOut> onFailure)
    {
        return result.IsSuccess
            ? onSuccess(result.Value)
            : onFailure(result.Errors);
    }


    public static async Task<TOut> Match<TIn, TOut>(this Task<Result<TIn>> result,
        Func<TIn, TOut> onSuccess, Func<Error[], TOut> onFailure)
    {
        var res = await result;

        return res.IsSuccess
            ? onSuccess(res.Value)
            : onFailure(res.Errors);
    }

    //public static async Task<Result<TOut>> Match<TIn, TOut>(this Result<TIn> result, Func<TIn, Task<TOut>> onSuccess, Error error) =>
    //    result.IsSuccess ?
    //        Result.Success(await onSuccess(result.Value)) :
    //        Result.Failure<TOut>(error);

    public static async Task<TOut> Match<TIn, TOut>(this Result<TIn> result, Func<TIn, TOut> onSuccess,
        Func<Error[], TOut> onFailure)
        => result.IsSuccess
            ? await Task.FromResult(onSuccess(result.Value))
            : await Task.FromResult(onFailure(result.Errors));
}