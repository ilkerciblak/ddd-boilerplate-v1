using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TikRandevu.Modules.Suppliers.Application.SupplierProvisions.GetAllSupplierProvisions;
using TikRandevu.Shared.Presentation.ApiResult;
using TikRandevu.Shared.Presentation.EndPoints;

namespace TikRandevu.Modules.Suppliers.Presentation.SupplierRezervations;

public sealed class GetAllSupplierRezervations : IEndPoint
{
    public void MapEndPoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
            "supplier-rezervations",
            async ([AsParameters] Guid supplierId, ISender sender) =>
        {
            var result = await sender.Send(new GetAllSupplierProvisionsQuery(supplierId));

            return result.Match(Results.Ok, ApiResult.Problem);
        });


        app.MapGet(
            "suppliers/{supplierId}/rezervations",
            async (Guid supplierId, ISender sender) =>
            {
                var result = await sender.Send(new GetAllSupplierProvisionsQuery(supplierId));

                return result.Match(Results.Ok, ApiResult.Problem);
            });
    }
}