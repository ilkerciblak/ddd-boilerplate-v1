using TikRandevu.Shared.Application.RequestBase;

namespace TikRandevu.Modules.Suppliers.Application.Suppliers.StoreSupplier;

public sealed record StoreSupplierCommand(string Name, string FullAddress) : ICommand<Guid>;