using TikRandevu.Modules.Suppliers.Domain.SupplierRezervations;
using TikRandevu.Modules.Suppliers.Domain.Suppliers;
using TikRandevu.Shared.Application.RequestBase;
using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Modules.Suppliers.Application.SupplierRezervations.GetAllRezervations;

public sealed class GetAllSupplierRezervationsQueryHandler(ISupplierRezervationRepository repo)
    : IQueryHandler<GetAllSupplierRezervationsQuery, IReadOnlyCollection<SupplierRezervation>>
{
    public async Task<Result<IReadOnlyCollection<SupplierRezervation>>> Handle(GetAllSupplierRezervationsQuery request,
        CancellationToken cancellationToken)
    {
        var rezervations = await repo.GetAllAsync(supplierId: request.SupplierId, cancellationToken: cancellationToken);

        return rezervations;
    }
}