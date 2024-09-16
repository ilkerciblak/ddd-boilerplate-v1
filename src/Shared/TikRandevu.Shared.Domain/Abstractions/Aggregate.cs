using TikRandevu.Shared.Domain.Contracts;

namespace TikRandevu.Shared.Domain.Abstractions;

public abstract class Aggregate : IEntity
{
    public Guid Identifier { get; }
    public bool IsArchived { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }
    public DateTime DeletedAt { get; }

    private readonly List<IDomainEvent> _domainEvents = [];

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.ToList();

    protected Aggregate()
    {
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