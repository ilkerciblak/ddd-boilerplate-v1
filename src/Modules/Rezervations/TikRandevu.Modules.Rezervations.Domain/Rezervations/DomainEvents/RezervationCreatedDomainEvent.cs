using TikRandevu.Shared.Domain.Abstractions;

namespace TikRandevu.Modules.Rezervations.Domain.Rezervations.DomainEvents;

public sealed class RezervationCreatedDomainEvent(Guid rezervationId) : DomainEvent
{
    public Guid RezervationId { get; init; } = rezervationId;
};