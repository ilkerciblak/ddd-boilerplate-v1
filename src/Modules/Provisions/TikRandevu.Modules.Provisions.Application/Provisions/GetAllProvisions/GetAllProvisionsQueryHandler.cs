using TikRandevu.Modules.Provisions.Domain;
using TikRandevu.Shared.Application.RequestBase;
using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Modules.Provisions.Application.Provisions.GetAllProvisions;

public sealed class GetAllProvisionsQueryHandler(IProvisionRepository provisionRepository)
    : IQueryHandler<GetAllProvisionQuery, IReadOnlyCollection<Provision>>
{
    public async Task<Result<IReadOnlyCollection<Provision>>> Handle(GetAllProvisionQuery request,
        CancellationToken cancellationToken)
    {
        var list = await provisionRepository.GetAllAsync(request.PageNumber, request.PageSize);

        return list;
    }
}