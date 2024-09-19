using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TikRandevu.Modules.Rezervations.Application.Rezervations.CreateRezervation;
using TikRandevu.Shared.Presentation.ApiResult;
using TikRandevu.Shared.Presentation.EndPoints;

// ReSharper disable InconsistentNaming

namespace TikRandevu.Modules.Rezervations.Presentation.Rezervations;

public class CreateRezervation : IEndPoint
{
    public void MapEndPoint(IEndpointRouteBuilder app)
    {
        app.MapPost(
            "rezervations",
            async ([FromBody] CreateRezervationRequest request, ISender sender) =>
            {
                var result = await sender.Send(
                    new CreateRezervationCommand(
                        request.supplierId,
                        request.customerId,
                        request.supplierProvisionId,
                        request.rezervationDate)
                );

                return result.Match(Results.Ok, ApiResult.Problem);
            });
    }
}

public sealed record CreateRezervationRequest(
    Guid supplierId,
    Guid supplierProvisionId,
    Guid customerId,
    DateTime rezervationDate);