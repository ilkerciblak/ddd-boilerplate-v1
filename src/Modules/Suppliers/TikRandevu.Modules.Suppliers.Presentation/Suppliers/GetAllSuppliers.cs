using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TikRandevu.Modules.Suppliers.Application.Suppliers.GetAllSupplier;
using TikRandevu.Shared.Presentation.ApiResult;
using TikRandevu.Shared.Presentation.EndPoints;

namespace TikRandevu.Modules.Suppliers.Presentation.Suppliers;

public sealed class GetAllSuppliers : IEndPoint
{
    public void MapEndPoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
            pattern: "/suppliers",
            async (ISender sender) =>
            {
                var result = await sender.Send(new GetAllSupplierQuery());

                return result.Match(Results.Ok, ApiResult.Problem);
            }
        );
    }
}