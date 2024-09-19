using TikRandevu.Modules.Suppliers.Domain.SupplierProvisions;
using TikRandevu.Shared.Application.RequestBase;

namespace TikRandevu.Modules.Suppliers.Application.SupplierProvisions.GetAllSupplierProvisions;

public sealed record GetAllSupplierProvisionsQuery(Guid? SupplierId = null)
    : IQuery<IReadOnlyCollection<SupplierProvision>>;
