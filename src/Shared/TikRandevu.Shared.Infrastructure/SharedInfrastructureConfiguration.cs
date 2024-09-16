using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

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


        return services;
    }
}