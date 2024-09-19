using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TikRandevu.Shared.Domain.Contracts;

namespace TikRandevu.Shared.Domain.Abstractions;

public abstract class Aggregate : IEntity
{
    

    public Guid Identifier { get; set;}
    public bool IsArchived { get; set;}
    public DateTime CreatedAt { get; set;}
    public DateTime UpdatedAt { get; set;}
    public DateTime DeletedAt { get; set;}

    private readonly List<IDomainEvent> _domainEvents = [];

    [NotMapped]
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.ToList();

    protected Aggregate()
    {
    }
    
    [JsonConstructor]
    protected Aggregate(Guid identifier, bool isArchived, DateTime createdAt, DateTime updatedAt, DateTime deletedAt)
    {
        Identifier = identifier;
        IsArchived = isArchived;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        DeletedAt = deletedAt;
    }


    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    public void Raise(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}