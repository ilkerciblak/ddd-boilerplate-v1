namespace TikRandevu.Shared.Domain.ResponseFoundation;

public record AlreadyArchived<T> : Error
{
    public AlreadyArchived() 
        : base(
        code: $"{typeof(T).Name}.AlreadyArchived",
        description: $"{typeof(T).Name} Already Archived",
        errorType: ErrorType.Problem)
    {
    }
}