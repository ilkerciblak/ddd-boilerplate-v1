using TikRandevu.Modules.Suppliers.Domain.Suppliers;
using TikRandevu.Shared.Application.RequestBase;

namespace TikRandevu.Modules.Suppliers.Application.Suppliers.GetAllSupplier;

public sealed record GetAllSupplierQuery() : IQuery<IReadOnlyCollection<Supplier>>;