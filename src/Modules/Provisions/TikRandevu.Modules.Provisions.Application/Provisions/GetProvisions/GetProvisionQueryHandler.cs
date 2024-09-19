using TikRandevu.Modules.Provisions.Domain;
using TikRandevu.Shared.Application.RequestBase;
using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Modules.Provisions.Application.Provisions.GetProvisions;

public class GetProvisionQueryHandler(IProvisionRepository repo)
    : IQueryHandler<GetProvisionQuery, Provision>
{
    public async Task<Result<Provision>> Handle(GetProvisionQuery request, CancellationToken cancellationToken)
    {
        var provision = await repo.GetAsync(request.Identifier);
        if (provision is null)
        {
            return Result<Provision>.Failure<Provision>(ProvisionError.NotFound(request.Identifier));
        }

        return provision;
    }
}