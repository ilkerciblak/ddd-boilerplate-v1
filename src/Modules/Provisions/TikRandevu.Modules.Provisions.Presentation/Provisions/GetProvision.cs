using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TikRandevu.Modules.Provisions.Application.Provisions.GetProvisions;
using TikRandevu.Shared.Presentation.ApiResult;
using TikRandevu.Shared.Presentation.EndPoints;

namespace TikRandevu.Modules.Provisions.Presentation.Provisions;

public sealed class GetProvision : IEndPoint
{
    public void MapEndPoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
            "provisions/{id}",
            async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new GetProvisionQuery(id));

                return result.Match(Results.Ok, ApiResult.Problem);
            }
        );
    }
}