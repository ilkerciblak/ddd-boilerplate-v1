namespace TikRandevu.Shared.Application.EventBus;

public abstract class IntegrationEvent : IIntegrationEvent
{
    public Guid EventId { get; }
    public DateTime OccuredAtUtc { get; }

    protected IntegrationEvent()
    {
        EventId = Guid.NewGuid();
        OccuredAtUtc = DateTime.UtcNow;
    }
    
    
    protected IntegrationEvent(Guid identifier, DateTime occuredAtUtc)
    {
        EventId = identifier;
        OccuredAtUtc = occuredAtUtc;
    }
    
}