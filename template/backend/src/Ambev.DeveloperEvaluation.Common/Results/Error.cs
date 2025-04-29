namespace Ambev.DeveloperEvaluation.Common.Results;

public record Error
{
    public Error(string code, string description, ErrorType type)
    {
        Code = code;
        Description = description ?? string.Empty;
        Type = type;
    }

    public string Code { get; set; }
    public string Description { get; set; }
    public ErrorType Type { get; set; }

    public static Error None => new (string.Empty, string.Empty, ErrorType.Failure);
    public static Error NullValue = new ("NullValue", "Field null value", ErrorType.Validation);
    public static Error FailCreated = new ("FailCreated", "Fail result is created without any error.", ErrorType.Conflict);
    public static Error Failure(string code, string description) =>
        new (code, description, ErrorType.Failure);
    public static Error Validation(string code, string description) =>
        new (code, description, ErrorType.Validation);
    public static Error Problem(string code, string description) =>
        new (code, description, ErrorType.Problem);
    public static Error NotFound(string code, string description) =>
        new (code, description, ErrorType.NotFound);
    public static Error Conflict(string code, string description) =>
        new (code, description, ErrorType.Conflict);
    public static Error Exception(string description) =>
        new("Error Exception", description, ErrorType.Exception);

    public static implicit operator Result(Error error) => Result.Failure(error);
}