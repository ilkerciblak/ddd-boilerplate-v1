using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TikRandevu.Modules.Rezervations.Application.Abstractions.Data;
using TikRandevu.Modules.Rezervations.Domain.Rezervations;
using TikRandevu.Modules.Rezervations.Infrastructure.Database;
using TikRandevu.Modules.Rezervations.Infrastructure.Rezervations;
using TikRandevu.Shared.Infrastructure.Interceptors;

namespace TikRandevu.Modules.Rezervations.Infrastructure;

public static class RezervationsRegistrar
{
    public static IServiceCollection RegisterRezervationsModule(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddInfrastructureServices(
            configuration.GetConnectionString("Database")!
        );

        return services;
    }

    private static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        string dbConnectionString)
    {
        services.AddDbContext<RezervationsDbContext>(
            (sp, opt) =>
                opt.UseNpgsql(
                        connectionString: dbConnectionString!,
                        builder => builder.MigrationsHistoryTable("Migrations"))
                    .AddInterceptors(
                        sp.GetRequiredService<PublishDomainEventInterceptor>()
                    )
        );

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<RezervationsDbContext>());
        services.AddScoped<IRezervationRepository, RezervationsRepository>();
        return services;
    }
}