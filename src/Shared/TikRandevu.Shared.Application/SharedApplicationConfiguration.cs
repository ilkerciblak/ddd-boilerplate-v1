using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TikRandevu.Shared.Application.Behaviors;

namespace TikRandevu.Shared.Application;

public static class SharedApplicationConfiguration
{
    public static IServiceCollection ApplySharedApplicationServices(
        this IServiceCollection service,
        Assembly[] assemblies
    )
    {


        service.AddMediatR(cfg =>
        {

            cfg.RegisterServicesFromAssemblies(assemblies);

            cfg.AddOpenBehavior(typeof(RequestExceptionHandlingBehavior<,>));
            cfg.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
        });

        service.AddValidatorsFromAssemblies(assemblies, includeInternalTypes: true);

        return service;
    }
}