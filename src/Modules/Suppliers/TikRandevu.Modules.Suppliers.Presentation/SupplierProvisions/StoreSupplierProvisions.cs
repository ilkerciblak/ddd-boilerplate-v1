using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TikRandevu.Modules.Suppliers.Application.SupplierProvisions.StoreSupplierProvisions;
using TikRandevu.Shared.Presentation.ApiResult;
using TikRandevu.Shared.Presentation.EndPoints;

namespace TikRandevu.Modules.Suppliers.Presentation.SupplierProvisions;

public sealed class StoreSupplierProvisions : IEndPoint
{
    public void MapEndPoint(IEndpointRouteBuilder app)
    {
        app.MapPost(
            "supplier-provisions",
            async ([FromBody] StoreSupplierProvisionRequest request, ISender sender) =>
            {
                var result =
                    await sender.Send(new StoreSupplierProvisionCommand(request.supplierId, request.provisionId,
                        request.price));

                return result.Match(Results.Ok, ApiResult.Problem);
            }
        );
    }
}

public sealed record StoreSupplierProvisionRequest(Guid supplierId, Guid provisionId, decimal price);