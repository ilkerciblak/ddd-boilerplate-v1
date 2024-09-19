using TikRandevu.Modules.Suppliers.Domain.SupplierProvisions;
using TikRandevu.Shared.Application.RequestBase;
using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Modules.Suppliers.Application.SupplierProvisions.GetAllSupplierProvisions;

public sealed class GetAllSupplierProvisionsQueryHandler(ISupplierProvisionRepository repo) 
: IQueryHandler<GetAllSupplierProvisionsQuery, IReadOnlyCollection<SupplierProvision>>
{
    public async Task<Result<IReadOnlyCollection<SupplierProvision>>> Handle(GetAllSupplierProvisionsQuery request, CancellationToken cancellationToken)
    {
        var list = await repo.GetAllAsync(request.SupplierId, cancellationToken);

        return list;
    }
}