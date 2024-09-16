using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using StackExchange.Redis;
using TikRandevu.Shared.Application.Caching;
using TikRandevu.Shared.Infrastructure.Caching;
using TikRandevu.Shared.Infrastructure.Interceptors;

namespace TikRandevu.Shared.Infrastructure;

public static class SharedInfrastructureConfiguration
{
    public static IServiceCollection ApplySharedInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        IConnectionMultiplexer? connectionMultiplexer = ConnectionMultiplexer.Connect(
            configuration.GetConnectionString("Redis")!
        );

        services.AddSingleton(connectionMultiplexer);
        
        services.AddStackExchangeRedisCache(opt =>
        {
            opt.ConnectionMultiplexerFactory = () => Task.FromResult(connectionMultiplexer);
        });

        services.TryAddSingleton<PublishDomainEventInterceptor>();
        services.TryAddSingleton<ICacheService, CacheService>();

        return services;
    }
}