using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TikRandevu.Modules.Suppliers.Application.SupplierProvisions.GetAllSupplierProvisions;
using TikRandevu.Shared.Presentation.ApiResult;
using TikRandevu.Shared.Presentation.EndPoints;

namespace TikRandevu.Modules.Suppliers.Presentation.SupplierProvisions;

public class GetAllSupplierProvisions : IEndPoint
{
    public void MapEndPoint(IEndpointRouteBuilder app)
    {
        app.MapGet("supplier-provisions/",
            async ([AsParameters] Guid supplierId, ISender sender) =>
            {
                var results = await sender.Send(new GetAllSupplierProvisionsQuery(supplierId));

                return results.Match(Results.Ok, ApiResult.Problem);
            });


        app.MapGet(
            "suppliers/{supplierId}/provisions",
            async (Guid supplierId, ISender sender) =>
            {
                var results = await sender.Send(new GetAllSupplierProvisionsQuery(supplierId));

                return results.Match(Results.Ok, ApiResult.Problem);
            });
    }
}