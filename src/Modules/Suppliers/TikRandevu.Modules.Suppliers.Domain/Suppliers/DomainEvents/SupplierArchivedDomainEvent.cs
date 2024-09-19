using TikRandevu.Shared.Domain.Abstractions;

namespace TikRandevu.Modules.Suppliers.Domain.Suppliers.DomainEvents;

public sealed class SupplierArchivedDomainEvent(Guid supplierId) : DomainEvent
{
    public Guid SupplierId { get; init; } = supplierId;
}