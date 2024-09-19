using TikRandevu.Shared.Application.RequestBase;

namespace TikRandevu.Modules.Suppliers.Application.SupplierRezervations.StoreSupplierRezervations;

public sealed record StoreSupplierRezervationsCommand(
    Guid SupplierId,
    Guid ProvisionId,
    Guid CustomerId,
    DateTime RezervationDate) : ICommand<Guid>;