using TikRandevu.Shared.Domain.Contracts;

namespace TikRandevu.Shared.Domain.Abstractions;

public abstract class DomainEvent  : IDomainEvent{
    public Guid DomainEventId { get; }
    public DateTime OccurredAt { get; }

    protected DomainEvent()
    {
        DomainEventId = Guid.NewGuid();
        OccurredAt = DateTime.UtcNow;
    }
}