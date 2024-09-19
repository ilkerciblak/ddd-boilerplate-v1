using TikRandevu.Modules.Suppliers.Domain.SupplierProvisions;
using TikRandevu.Modules.Suppliers.PublicAPI.SupplierProvisions;

namespace TikRandevu.Modules.Suppliers.Presentation.SupplierProvisions.PublicApi;

public sealed class SupplierProvisionsApi(ISupplierProvisionRepository repo)
    : ISupplierProvisionsApi
{
    public async Task<SupplierProvisionResponse?> GetAsync(Guid identifier,
        CancellationToken cancellationToken = default)
    {
        var res = await repo.GetAsync(identifier, cancellationToken);
        return res is not null
            ? new SupplierProvisionResponse(identifier, res.SupplierId, res.ProvisionId, res.Price)
            : null;
    }
}