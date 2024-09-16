using TikRandevu.Shared.Domain.Contracts;

namespace TikRandevu.Shared.Domain.Abstractions;

public abstract  class Entity : IEntity
{
    public Guid Identifier { get; private set;}
    public bool IsArchived { get; private set;}
    public DateTime CreatedAt { get; private set;}
    public DateTime UpdatedAt { get; private set;}
    public DateTime DeletedAt { get; private set;}

    protected Entity()
    {
        
    }
    
}