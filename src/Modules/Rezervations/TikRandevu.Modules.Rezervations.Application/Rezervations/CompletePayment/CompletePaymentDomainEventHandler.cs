using MediatR;
using TikRandevu.Modules.Rezervations.Application.Rezervations.IntegrationEvents;
using TikRandevu.Modules.Rezervations.Domain.Rezervations;
using TikRandevu.Modules.Rezervations.Domain.Rezervations.DomainEvents;
using TikRandevu.Shared.Application;
using TikRandevu.Shared.Application.EventBus;
using TikRandevu.Shared.Application.Messaging;
using TikRandevu.Shared.Domain.Contracts;
using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Modules.Rezervations.Application.Rezervations.CompletePayment;

public class CompletePaymentDomainEventHandler(ISender sender, IEventBus eventBus, IRezervationRepository repo)
    : IDomainEventHandler<RezervationPaidDomainEvent>
{
    public async Task Handle(RezervationPaidDomainEvent notification, CancellationToken cancellationToken)
    {
        var rezervation = await repo.GetAsync(notification.RezervationId, cancellationToken);

        if (rezervation is null)
        {
            throw new DomainException("DomainEvent", new NotFound<Rezervation>(notification.RezervationId));
        }

        await eventBus.PublishAsync(
            new CompletePaymentIntegrationEvent(
                notification.DomainEventId,
                notification.OccurredAt,
                "ananza",
                rezervation.SupplierId,
                rezervation.CustomerId,
                rezervation.SupplierProvisionId,
                rezervation.RezervationDate
            ),
            cancellationToken
        );
    }
}