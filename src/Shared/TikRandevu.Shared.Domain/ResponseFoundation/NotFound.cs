namespace TikRandevu.Shared.Domain.ResponseFoundation;

public record NotFound<T> : Error
{
    protected NotFound(T entity, Guid id) :
        base(
            code: $"{typeof(T).Name}.NotFound",
            description: $"{typeof(T).Name} Not Found with identifier {id}",
            errorType: ErrorType.NotFound)
    {
    }
}