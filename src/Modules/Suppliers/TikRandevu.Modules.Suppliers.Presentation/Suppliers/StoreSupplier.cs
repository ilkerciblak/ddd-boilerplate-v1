using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TikRandevu.Modules.Suppliers.Application.Suppliers.StoreSupplier;
using TikRandevu.Shared.Presentation.ApiResult;
using TikRandevu.Shared.Presentation.EndPoints;

namespace TikRandevu.Modules.Suppliers.Presentation.Suppliers;

public sealed class StoreSupplier : IEndPoint
{
    public void MapEndPoint(IEndpointRouteBuilder app)
    {
        app.MapPost(
            "suppliers",
            async ([FromBody] StoreSupplierRequest request,ISender sender) =>
            {
                var result = await sender.Send(new StoreSupplierCommand(request.name, request.fullAddress));

                return result.Match(Results.Ok, ApiResult.Problem);
            }
        );
    }
}


public sealed record StoreSupplierRequest(string name, string fullAddress);