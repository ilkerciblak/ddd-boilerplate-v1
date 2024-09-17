using MediatR;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TikRandevu.Shared.Domain.Abstractions;
using TikRandevu.Shared.Domain.Contracts;

namespace TikRandevu.Shared.Infrastructure.Interceptors;

public sealed class PublishDomainEventInterceptor(IServiceScopeFactory factory, ILogger<PublishDomainEventInterceptor> logger) : SaveChangesInterceptor
{
    public override async ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        await PublishDomainEventAsync(eventData, cancellationToken);
        
        return await base.SavedChangesAsync(eventData, result, cancellationToken);
    }

    private async Task PublishDomainEventAsync(
        SaveChangesCompletedEventData eventData,
        CancellationToken cancellationToken)
    {
        var domainEvents = eventData
            .Context
            .ChangeTracker
            .Entries<Aggregate>()
            .Select(x => x.Entity)
            .SelectMany(e =>
            {
                IReadOnlyCollection<IDomainEvent> domainEvents = e.DomainEvents;

                e.ClearDomainEvents();

                return domainEvents;
            });


        using IServiceScope scope = factory.CreateScope();

        IPublisher publisher = scope.ServiceProvider.GetRequiredService<IPublisher>();
        
        foreach (var domainEvent in domainEvents)
        {
            await publisher.Publish(domainEvent, cancellationToken);
            logger.LogInformation("Domain Event {DomainEvent} published with id: {EventId}", [nameof(domainEvent), domainEvent.DomainEventId]);
        }
    }
}