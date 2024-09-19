using TikRandevu.Modules.Rezervations.Application.Abstractions.Data;
using TikRandevu.Modules.Rezervations.Domain.Rezervations;
using TikRandevu.Modules.Suppliers.PublicAPI.SupplierProvisions;
using TikRandevu.Modules.Suppliers.PublicAPI.Suppliers;
using TikRandevu.Shared.Application.RequestBase;
using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Modules.Rezervations.Application.Rezervations.CreateRezervation;

public sealed class CreateRezervationCommandHandler(
    IRezervationRepository repo,
    IUnitOfWork unitOfWork,
    ISupplierApi supplierApi,
    ISupplierProvisionsApi provisionsApi
    )
    : ICommandHandler<CreateRezervationCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateRezervationCommand request, CancellationToken cancellationToken)
    {
        // Check if customer exists
        // Check if supplier and supplierprovision exists
        var supplierResponse = await supplierApi.GetSupplierAsync(request.SupplierId, cancellationToken);

        if (supplierResponse is null)
        {
            return Result<Guid>.Failure<Guid>(new NotFound<SupplierResponse>(request.SupplierId));
        }


        var provisionResponse = await provisionsApi.GetAsync(request.SupplierProvisionId, cancellationToken);

        if (provisionResponse is null)
        {
            return Result<Guid>.Failure<Guid>(new NotFound<SupplierProvisionResponse>(request.SupplierId));
        }
        
        var result = Rezervation.Create(
            request.SupplierId,
            request.SupplierProvisionId, 
            request.CustomerId,
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