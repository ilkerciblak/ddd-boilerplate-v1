using TikRandevu.Modules.Suppliers.Application.Abstractions.Data;
using TikRandevu.Modules.Suppliers.Domain.Suppliers;
using TikRandevu.Shared.Application.RequestBase;
using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Modules.Suppliers.Application.Suppliers.StoreSupplier;

public sealed class StoreSupplierCommandHandler(ISupplierRepository repo, IUnitOfWork unitOfWork) : ICommandHandler<StoreSupplierCommand, Guid>
{
    public async Task<Result<Guid>> Handle(StoreSupplierCommand request, CancellationToken cancellationToken)
    {
        var result = Supplier.Create(request.Name, request.FullAddress);

        if (result.IsFailure)
        {
            return Result<Guid>.Failure<Guid>(result.Error);
        }

        await repo.Insert(result.Value, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return result.Value.Identifier;
    }
}