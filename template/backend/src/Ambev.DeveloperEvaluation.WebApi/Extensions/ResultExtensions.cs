using Ambev.DeveloperEvaluation.Common.Results;

namespace Ambev.DeveloperEvaluation.WebApi.Extensions;

public static class ResultExtensions
{
    public static IResult MapResult<T>(this IResultExtensions resultExtensions, Result<T> result)
    {
        return result.IsSuccess
            ? Microsoft.AspNetCore.Http.Results.Ok(result.Value)
            : GetErrorResult(result.Errors[0]);
    }

    internal static IResult GetErrorResult(Error error) =>
        error.Type switch
        {
            ErrorType.Validation => Microsoft.AspNetCore.Http.Results.BadRequest(error),
            ErrorType.NotFound => Microsoft.AspNetCore.Http.Results.NotFound(error),
            ErrorType.Conflict => Microsoft.AspNetCore.Http.Results.Conflict(error),
            _ => Microsoft.AspNetCore.Http.Results.Problem(
                title: GetTitle(error),
                detail: GetDetail(error),
                type: GetType(error.Type),
                statusCode: GetStatusCode(error.Type),
                extensions: GetErrors(error)
            )
        };

    internal static string GetTitle(Error error)
    {
        return error.Type switch
        {
            ErrorType.Validation => error.Code,
            ErrorType.Problem => error.Code,
            ErrorType.NotFound => error.Code,
            ErrorType.Conflict => error.Code,
            _ => "Server Failure"
        };
    }

    internal static string GetDetail(Error error)
    {
        return error.Type switch
        {
            ErrorType.Validation => error.Description,
            ErrorType.Problem => error.Description,
            ErrorType.NotFound => error.Description,
            ErrorType.Conflict => error.Description,
            _ => "Server Failure"
        };
    }

    internal static string GetType(ErrorType errorType)
    {
        return errorType switch
        {
            ErrorType.Validation => "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            ErrorType.Problem => "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            ErrorType.NotFound => "https://tools.ietf.org/html/rfc7231#section-6.5.4",
            ErrorType.Conflict => "https://tools.ietf.org/html/rfc7231#section-6.5.8",
            _ => "https://tools.ietf.org/html/rfc7231#section-6.6.1"
        };
    }

    internal static int GetStatusCode(ErrorType errorType)
    {
        return errorType switch
        {
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.Problem => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };
    }

    internal static Dictionary<string, object?> GetErrors(Error error) =>
        new()
        {
            {"errors", error }
        };
}