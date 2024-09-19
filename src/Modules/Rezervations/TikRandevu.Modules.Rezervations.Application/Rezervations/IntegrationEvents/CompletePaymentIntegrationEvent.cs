using TikRandevu.Shared.Application.EventBus;

namespace TikRandevu.Modules.Rezervations.Application.Rezervations.IntegrationEvents;

public class CompletePaymentIntegrationEvent : IntegrationEvent
{
    public string CustomerName { get; set; }
    public Guid SupplierId { get; set; }
    public Guid CustomerId { get; set; }
    public Guid ProvisionId { get; set; }
    public DateTime Date { get; set; }

    public CompletePaymentIntegrationEvent()
    {
        
    }

    public CompletePaymentIntegrationEvent(
        Guid identifier,
        DateTime occuredAtUtc,
        string customerName,
        Guid supplierId,
        Guid customerId,
        Guid provisionId,
        DateTime date
    ) : base(identifier, occuredAtUtc)
    {
        CustomerName = customerName;
        SupplierId = supplierId;
        CustomerId = customerId;
        ProvisionId = provisionId;
        Date = date;
    }
}