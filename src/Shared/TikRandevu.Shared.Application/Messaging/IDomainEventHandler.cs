using MediatR;
using TikRandevu.Shared.Domain.Contracts;

namespace TikRandevu.Shared.Application.Messaging;

public interface IDomainEventHandler<in TDomainEvent> : INotificationHandler<TDomainEvent>, IDomainEventHandler
    where TDomainEvent : IDomainEvent;


public interface IDomainEventHandler 
{
    Task Handle(IDomainEvent domainEvent, CancellationToken cancellationToken = default);
}