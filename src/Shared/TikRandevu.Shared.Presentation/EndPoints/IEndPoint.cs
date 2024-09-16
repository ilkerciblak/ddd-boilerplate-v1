using Microsoft.AspNetCore.Routing;

namespace TikRandevu.Shared.Presentation.EndPoints;

public interface IEndPoint
{
    void MapEndPoint(IEndpointRouteBuilder app);
}