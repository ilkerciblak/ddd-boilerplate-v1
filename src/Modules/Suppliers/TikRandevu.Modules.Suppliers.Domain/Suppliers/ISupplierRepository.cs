using TikRandevu.Shared.Domain.Contracts;

namespace TikRandevu.Modules.Suppliers.Domain.Suppliers;

public interface ISupplierRepository : IRepository<Supplier>
{
    Task<List<Supplier>> GetAllAsync(CancellationToken cancellationToken = default);
}