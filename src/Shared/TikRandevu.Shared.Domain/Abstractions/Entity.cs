using System.Text.Json.Serialization;
using TikRandevu.Shared.Domain.Contracts;

namespace TikRandevu.Shared.Domain.Abstractions;

public abstract class Entity : IEntity
{
    public Guid Identifier { get;  set; }
    public bool IsArchived { get;  set; }
    public DateTime CreatedAt { get;  set; }
    public DateTime UpdatedAt { get;  set; }
    public DateTime DeletedAt { get;  set; }

    protected Entity()
    {
    }

    [JsonConstructor]
    protected Entity(Guid identifier, bool isArchived, DateTime createdAt, DateTime updatedAt, DateTime deletedAt)
    {
        Identifier = identifier;
        IsArchived = isArchived;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        DeletedAt = deletedAt;
    }
}