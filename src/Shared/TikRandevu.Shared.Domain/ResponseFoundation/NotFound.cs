namespace TikRandevu.Shared.Domain.ResponseFoundation;

public record NotFound<T> : Error
{
    public NotFound(Guid id) :
        base(
            code: $"{typeof(T).Name}.NotFound",
            description: $"{typeof(T).Name} Not Found with identifier {id}",
            errorType: ErrorType.NotFound)
    {
    }
}