namespace TikRandevu.Modules.Suppliers.PublicAPI.Suppliers;

public interface ISupplierApi
{
    Task<SupplierResponse?> GetSupplierAsync(Guid identifier, CancellationToken cancellationToken = default);
}