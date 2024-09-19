using TikRandevu.Shared.Domain.Contracts;

namespace TikRandevu.Modules.Suppliers.Domain.SupplierProvisions;

public interface ISupplierProvisionRepository : IRepository<SupplierProvision>
{
    Task<List<SupplierProvision>> GetAllAsync(Guid? supplierId,CancellationToken cancellationToken = default);
}