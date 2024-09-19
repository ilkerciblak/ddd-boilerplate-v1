using TikRandevu.Modules.Suppliers.Domain.Suppliers;
using TikRandevu.Shared.Application.RequestBase;

namespace TikRandevu.Modules.Suppliers.Application.Suppliers.GetSupplier;

public sealed record GetSupplierQuery(Guid Identifier) : IQuery<Supplier>;