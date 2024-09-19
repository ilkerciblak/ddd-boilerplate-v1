// ReSharper disable InconsistentNaming

using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.WebUtilities;
using TikRandevu.Modules.Rezervations.Application.Rezervations.CompletePayment;
using TikRandevu.Shared.Presentation.ApiResult;
using TikRandevu.Shared.Presentation.EndPoints;

namespace TikRandevu.Modules.Rezervations.Presentation.Rezervations;

public class CompletePayment : IEndPoint
{
    public void MapEndPoint(IEndpointRouteBuilder app)
    {
        app.MapPut(
            "rezervations/pay",
            async ([FromBody] CompletePaymentRequest request, ISender sender) =>
            {
                var result = await sender.Send(new CompletePaymentCommand(request.rezervationId));

                return result.Match(Results.Ok, ApiResult.Problem);
            }
        );
    }
}

public sealed record CompletePaymentRequest(Guid rezervationId);