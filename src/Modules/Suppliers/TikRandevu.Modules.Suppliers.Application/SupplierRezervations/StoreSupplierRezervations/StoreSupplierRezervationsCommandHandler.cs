using TikRandevu.Modules.Suppliers.Application.Abstractions.Data;
using TikRandevu.Modules.Suppliers.Domain.SupplierRezervations;
using TikRandevu.Modules.Suppliers.Domain.Suppliers;
using TikRandevu.Shared.Application.RequestBase;
using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Modules.Suppliers.Application.SupplierRezervations.StoreSupplierRezervations;

public sealed class StoreSupplierRezervationsCommandHandler(ISupplierRezervationRepository repo, IUnitOfWork unitOfWork)
    : ICommandHandler<StoreSupplierRezervationsCommand, Guid>
{
    public async Task<Result<Guid>> Handle(StoreSupplierRezervationsCommand request, CancellationToken cancellationToken)
    {
        var result = SupplierRezervation.Create(request.SupplierId, request.ProvisionId, request.CustomerId,
            request.RezervationDate);

        if (result.IsFailure)
        {
            return Result<Guid>.Failure<Guid>(result.Error);
        }

        await repo.Insert(result.Value, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return result.Value.Identifier;
    }
}