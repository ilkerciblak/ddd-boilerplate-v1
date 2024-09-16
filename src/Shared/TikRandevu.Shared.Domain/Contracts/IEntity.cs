namespace TikRandevu.Shared.Domain.Contracts;

public interface IEntity
{ 
    Guid Identifier { get; }
    bool IsArchived { get; }
    DateTime CreatedAt { get; }
    DateTime UpdatedAt { get; }
    DateTime DeletedAt { get; }
}