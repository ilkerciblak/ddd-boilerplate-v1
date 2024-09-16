namespace TikRandevu.Shared.Domain.ResponseFoundation;

public record Error
{
    public string Code { get; private set; }
    public string Description { get; private set; }
    public ErrorType ErrorType { get; private set; }

    public Error(string code, string description, ErrorType errorType)
    {
        Code = code;
        Description = description;
        ErrorType = errorType;
    }

    public static readonly Error None =
        new Error(string.Empty, string.Empty, ErrorType.Problem);

    public static readonly Error NullValue =
        new Error("GeneralError.NullValue", "Unexpected Null Value", ErrorType.Problem);

    public static Error Problem(string code, string description)
        => new(code, description, ErrorType.Problem);

    public static Error Failure(string code, string description)
        => new(code, description, ErrorType.Failure);

    public static Error Validation(string code, string description)
        => new(code, description, ErrorType.Validation);

    public static Error NotFound(string code, string description)
        => new(code, description, ErrorType.NotFound);

    public static Error Conflict(string code, string description)
        => new(code, description, ErrorType.Conflict);
};