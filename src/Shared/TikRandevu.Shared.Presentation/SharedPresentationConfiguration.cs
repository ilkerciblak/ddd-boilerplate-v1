using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TikRandevu.Shared.Presentation.EndPoints;

namespace TikRandevu.Shared.Presentation;

public static class SharedPresentationConfiguration
{
    public static IServiceCollection AddEndPoints(
        this IServiceCollection service,
        Assembly[] assemblies)
    {
        ServiceDescriptor[]? serviceDescriptors = assemblies
            .SelectMany(a => a.GetTypes())
            .Where(type => type is { IsAbstract: false, IsInterface: false } && type.IsAssignableTo(typeof(IEndPoint)))
            .Select(type => ServiceDescriptor.Transient(typeof(IEndPoint), type))
            .ToArray();

        service.TryAddEnumerable(serviceDescriptors);

        return service;
    }

    public static IApplicationBuilder MapEndPoints(
        this WebApplication app,
        RouteGroupBuilder? routeGroupBuilder = null)
    {

        IEndpointRouteBuilder builder = routeGroupBuilder is null ? app : routeGroupBuilder;

        IEnumerable<IEndPoint> endPoints = app.Services.GetRequiredService<IEnumerable<IEndPoint>>();

        foreach (var endPoint in endPoints)
        {
            endPoint.MapEndPoint(builder);
        }
        
        return app;
    }
}