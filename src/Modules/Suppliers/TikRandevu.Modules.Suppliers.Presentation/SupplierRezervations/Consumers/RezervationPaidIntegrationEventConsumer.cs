using MassTransit;
using MediatR;
using TikRandevu.Modules.Rezervations.Application.Rezervations.IntegrationEvents;
using TikRandevu.Modules.Suppliers.Application.SupplierRezervations.StoreSupplierRezervations;
using TikRandevu.Shared.Application;

namespace TikRandevu.Modules.Suppliers.Presentation.SupplierRezervations.Consumers;

public class RezervationPaidIntegrationEventConsumer(ISender sender) : IConsumer<CompletePaymentIntegrationEvent>
{
    public async Task Consume(ConsumeContext<CompletePaymentIntegrationEvent> context)
    {
        var result = await sender.Send(new StoreSupplierRezervationsCommand(
            context.Message.SupplierId,
            context.Message.ProvisionId,
            context.Message.CustomerId,
            context.Message.Date
        ));

        if (result.IsFailure)
        {
            throw new DomainException(nameof(StoreSupplierRezervationsCommand), result.Error);
        }
    }
}