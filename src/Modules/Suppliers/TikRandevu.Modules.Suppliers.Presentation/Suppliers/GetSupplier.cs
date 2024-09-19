using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TikRandevu.Modules.Suppliers.Application.Suppliers.GetSupplier;
using TikRandevu.Shared.Presentation.ApiResult;
using TikRandevu.Shared.Presentation.EndPoints;

namespace TikRandevu.Modules.Suppliers.Presentation.Suppliers;

public class GetSupplier : IEndPoint
{
    public void MapEndPoint(IEndpointRouteBuilder app)
    {
        app.MapGet("suppliers/{supplierId}",
            async (Guid supplierId, ISender sender) =>
        {
            var result = await sender.Send(new GetSupplierQuery(supplierId));
            
            return result.Match(Results.Ok, ApiResult.Problem);
        });
        
    }
}