using TikRandevu.Modules.Suppliers.Domain.Suppliers;
using TikRandevu.Shared.Application.RequestBase;
using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Modules.Suppliers.Application.Suppliers.GetAllSupplier;

public sealed class GetAllSupplierQueryHandler(ISupplierRepository repo)
: IQueryHandler<GetAllSupplierQuery, IReadOnlyCollection<Supplier>>
{
    public async Task<Result<IReadOnlyCollection<Supplier>>> Handle(GetAllSupplierQuery request, CancellationToken cancellationToken)
    {
        var list = await repo.GetAllAsync(cancellationToken);

        return list;
    }
}