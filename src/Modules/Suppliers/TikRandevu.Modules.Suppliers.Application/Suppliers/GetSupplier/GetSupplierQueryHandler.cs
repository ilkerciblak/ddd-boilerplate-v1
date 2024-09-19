using TikRandevu.Modules.Suppliers.Domain.Suppliers;
using TikRandevu.Shared.Application.RequestBase;
using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Modules.Suppliers.Application.Suppliers.GetSupplier;

public sealed class GetSupplierQueryHandler(ISupplierRepository repo) : IQueryHandler<GetSupplierQuery, Supplier>
{
    public async Task<Result<Supplier>> Handle(GetSupplierQuery request, CancellationToken cancellationToken)
    {
        var supplier = await repo.GetAsync(request.Identifier, cancellationToken);

        if (supplier is null)
        {
            return Result<Supplier>.Failure<Supplier>(SupplierError.NotFound(request.Identifier));
        }

        return supplier;
    }
}