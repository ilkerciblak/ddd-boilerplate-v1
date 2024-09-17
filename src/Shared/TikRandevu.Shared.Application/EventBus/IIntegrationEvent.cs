namespace TikRandevu.Shared.Application.EventBus;

public interface IIntegrationEvent
{
    Guid EventId { get; }
    DateTime OccuredAtUtc { get; }
}