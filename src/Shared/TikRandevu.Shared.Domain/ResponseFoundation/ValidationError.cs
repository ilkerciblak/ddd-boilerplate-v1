namespace TikRandevu.Shared.Domain.ResponseFoundation;

public sealed record ValidationError : Error
{
    public Error[] Errors { get; private set; }

    public ValidationError(Error[] errors) :
        base(
            code: "GeneralError.ValidationError",
            description: "Validation Error(s) Occured",
            errorType: ErrorType.Validation)
    {
        this.Errors = errors;
    }

    // public static ValidationError FromResult(Result result)
    // {
    //     return new ValidationError();
    // }
    
}