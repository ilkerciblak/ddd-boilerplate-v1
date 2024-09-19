using TikRandevu.Shared.Domain.Abstractions;

namespace TikRandevu.Modules.Provisions.Domain.DomainEvents;

public sealed class ProvisionArchivedDomainEvent(Guid provisionId) : DomainEvent
{
    public Guid ProvisionId { get; init; } = provisionId;
}