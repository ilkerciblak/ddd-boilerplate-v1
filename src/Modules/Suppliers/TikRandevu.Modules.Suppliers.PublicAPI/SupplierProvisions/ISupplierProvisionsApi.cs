namespace TikRandevu.Modules.Suppliers.PublicAPI.SupplierProvisions;

public interface ISupplierProvisionsApi
{
    Task<SupplierProvisionResponse?> GetAsync(Guid identifier, CancellationToken cancellationToken = default);
}