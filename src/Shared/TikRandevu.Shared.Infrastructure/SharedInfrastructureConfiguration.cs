using Microsoft.Extensions.DependencyInjection;

namespace TikRandevu.Shared.Infrastructure;

public static class SharedInfrastructureConfiguration
{
    public static IServiceCollection ApplySharedInfrastructureServices(this IServiceCollection service)
    {
        return service;
    }
}