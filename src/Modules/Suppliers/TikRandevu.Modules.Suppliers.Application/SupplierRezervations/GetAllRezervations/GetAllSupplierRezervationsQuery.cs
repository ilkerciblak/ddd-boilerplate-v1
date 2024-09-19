using TikRandevu.Modules.Suppliers.Domain.SupplierRezervations;
using TikRandevu.Shared.Application.RequestBase;

namespace TikRandevu.Modules.Suppliers.Application.SupplierRezervations.GetAllRezervations;

public sealed record GetAllSupplierRezervationsQuery(Guid? SupplierId = null) : IQuery<IReadOnlyCollection<SupplierRezervation>>;