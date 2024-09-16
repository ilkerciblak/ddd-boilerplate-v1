using MediatR;

namespace TikRandevu.Shared.Domain.Contracts;

public interface IDomainEvent : INotification
{
    Guid DomainEventId { get; }
    DateTime OccurredAt { get; }
}