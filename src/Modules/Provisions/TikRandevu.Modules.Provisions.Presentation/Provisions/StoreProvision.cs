using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TikRandevu.Modules.Provisions.Application.Provisions.StoreProvisions;
using TikRandevu.Shared.Presentation.ApiResult;
using TikRandevu.Shared.Presentation.EndPoints;

namespace TikRandevu.Modules.Provisions.Presentation.Provisions;

public sealed class StoreProvision : IEndPoint
{
    public void MapEndPoint(IEndpointRouteBuilder app)
    {
        app.MapPost(
            "provisions",
            async ([FromBody] StoreProvisionRequest request, [FromServices] ISender sender) =>
            {
                var result = await sender.Send(new StoreProvisionCommand(request.name));

                return result.Match(Results.Ok, ApiResult.Problem);
            }
        );
    }
}


public sealed record StoreProvisionRequest(string name);