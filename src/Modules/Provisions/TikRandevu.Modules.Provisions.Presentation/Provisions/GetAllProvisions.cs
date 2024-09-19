using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TikRandevu.Modules.Provisions.Application.Provisions.GetAllProvisions;
using TikRandevu.Shared.Presentation.ApiResult;
using TikRandevu.Shared.Presentation.EndPoints;

namespace TikRandevu.Modules.Provisions.Presentation.Provisions;

public sealed class GetAllProvisions : IEndPoint
{
    public void MapEndPoint(IEndpointRouteBuilder app)
    {
        app.MapGet("provisions",
            async ([AsParameters] GetAllProvisionRequest request, [FromServices] ISender sender) =>
            {
                var result = await sender.Send(new GetAllProvisionQuery(request.pageNumber, request.pageSize));

                return result.Match(Results.Ok, ApiResult.Problem);
            }
            );
    }
}

public sealed record GetAllProvisionRequest(int? pageNumber = 1, int? pageSize=100);