using TikRandevu.Modules.Provisions.Application.Data;
using TikRandevu.Modules.Provisions.Domain;
using TikRandevu.Shared.Application.RequestBase;
using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Modules.Provisions.Application.Provisions.StoreProvisions;

internal sealed class StoreProvisionsCommandHandler(IProvisionRepository repo, IUnitOfWork unitOfWork)
: ICommandHandler<StoreProvisionCommand, Guid>
{
    public async Task<Result<Guid>> Handle(StoreProvisionCommand request, CancellationToken cancellationToken)
    {
        var provision = Provision.Create(request.Name);
        

        if (provision.IsFailure)
        {
            return Result<Guid>.Failure<Guid>(provision.Error);
        }

        await repo.Insert(provision.Value, cancellationToken);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return provision.Value.Identifier;

    }
}