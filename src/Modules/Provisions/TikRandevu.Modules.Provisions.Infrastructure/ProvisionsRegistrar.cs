using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TikRandevu.Modules.Provisions.Application.Data;
using TikRandevu.Modules.Provisions.Domain;
using TikRandevu.Modules.Provisions.Infrastructure.Database;
using TikRandevu.Modules.Provisions.Infrastructure.Provisions;
using TikRandevu.Shared.Infrastructure.Interceptors;

namespace TikRandevu.Modules.Provisions.Infrastructure;

public static class ProvisionsRegistrar
{
    public static IServiceCollection RegisterProvisionsModule(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddInfrastructureServices(
            dbConnectionString: configuration.GetConnectionString("Database")!
        );

        return services;
    }


    private static void AddInfrastructureServices(
        this IServiceCollection services,
        string dbConnectionString
    )
    {
        services.AddDbContext<ProvisionsDbContext>(
            (sp, opt) =>
            {
                opt.UseNpgsql(
                        dbConnectionString!,
                        builder => builder.MigrationsHistoryTable("Migrations"))
                    .AddInterceptors(
                        sp.GetRequiredService<PublishDomainEventInterceptor>()
                    );
            }
        );

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ProvisionsDbContext>());
        services.AddScoped<IProvisionRepository, ProvisionRepository>();
    }
}