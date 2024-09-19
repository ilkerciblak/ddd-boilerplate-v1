using TikRandevu.Shared.Application.RequestBase;

namespace TikRandevu.Modules.Suppliers.Application.SupplierProvisions.StoreSupplierProvisions;

public sealed record StoreSupplierProvisionCommand(Guid SupplierId, Guid ProvisionId, decimal Price)
    : ICommand<Guid>;