using TikRandevu.Modules.Suppliers.Domain.Suppliers;
using TikRandevu.Modules.Suppliers.PublicAPI.Suppliers;

namespace TikRandevu.Modules.Suppliers.Presentation.Suppliers.SupplierApi;

public sealed class SupplierApi(ISupplierRepository repo) 
    : ISupplierApi
{
    public async Task<SupplierResponse?> GetSupplierAsync(Guid identifier, CancellationToken cancellationToken = default)
    {
        var supplier = await repo.GetAsync(identifier, cancellationToken: cancellationToken);

        if (supplier is null)
        {
            return null;
        }

        return new SupplierResponse(Identifier: identifier, Name: supplier.Name, FullAddress: supplier.FullAddress);

    }
}