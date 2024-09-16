using MediatR;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using TikRandevu.Shared.Domain.Abstractions;
using TikRandevu.Shared.Domain.Contracts;

namespace TikRandevu.Shared.Infrastructure.Interceptors;

public sealed class PublishDomainEventInterceptor(IServiceScopeFactory factory) : SaveChangesInterceptor
{
    public override async ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result,
        CancellationToken cancellationToken = new CancellationToken())
    {
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
        }
    }
}