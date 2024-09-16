namespace TikRandevu.Shared.Domain.Contracts;

public interface IDomainEvent 
{
    Guid DomainEventId { get; }
    DateTime OccurredAt { get; }
}