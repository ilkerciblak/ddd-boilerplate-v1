using TikRandevu.Modules.Suppliers.Application.Abstractions.Data;
using TikRandevu.Modules.Suppliers.Domain.SupplierProvisions;
using TikRandevu.Shared.Application.RequestBase;
using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Modules.Suppliers.Application.SupplierProvisions.StoreSupplierProvisions;

public sealed class StoreSupplierProvisionCommandHandler(ISupplierProvisionRepository repo, IUnitOfWork unitOfWork)
: ICommandHandler<StoreSupplierProvisionCommand, Guid>
{
    public async Task<Result<Guid>> Handle(StoreSupplierProvisionCommand request, CancellationToken cancellationToken)
    {
        var supplierProvision = SupplierProvision.Create(request.ProvisionId, request.SupplierId, request.Price);
        if (supplierProvision.IsFailure)
        {
            return Result<Guid>.Failure<Guid>(supplierProvision.Error);
        }

        await repo.Insert(supplierProvision.Value, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return supplierProvision.Value.ProvisionId;

    }
}