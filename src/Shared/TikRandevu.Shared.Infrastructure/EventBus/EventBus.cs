using MassTransit;
using Microsoft.Extensions.Logging;
using TikRandevu.Shared.Application.EventBus;

namespace TikRandevu.Shared.Infrastructure.EventBus;

internal sealed class EventBus(IBus eventBus, ILogger<EventBus> logger) : IEventBus
{
    public async Task PublishAsync<TIntegrationEvent>(TIntegrationEvent integrationEvent, CancellationToken cancellationToken = default) 
        where TIntegrationEvent : IIntegrationEvent
    {
        logger.LogInformation("EventBus published an integration event to consumers :{IntegrationEvent}", nameof(integrationEvent));
        
        await eventBus.Publish(integrationEvent, cancellationToken);
    }
}