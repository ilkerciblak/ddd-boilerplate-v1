using TikRandevu.Shared.Domain.Contracts;

namespace TikRandevu.Modules.Suppliers.Domain.SupplierRezervations;

public interface ISupplierRezervationRepository : IRepository<SupplierRezervation>
{
    Task<List<SupplierRezervation>> GetAllAsync(Guid? supplierId = null,CancellationToken cancellationToken = default);
}