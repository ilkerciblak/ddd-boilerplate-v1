﻿using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TikRandevu.Modules.Suppliers.Application.Abstractions.Data;
using TikRandevu.Modules.Suppliers.Domain.SupplierProvisions;
using TikRandevu.Modules.Suppliers.Domain.SupplierRezervations;
using TikRandevu.Modules.Suppliers.Domain.Suppliers;
using TikRandevu.Modules.Suppliers.Infrastructure.Database;
using TikRandevu.Modules.Suppliers.Infrastructure.SupplierProvisions;
using TikRandevu.Modules.Suppliers.Infrastructure.SupplierRezervations;
using TikRandevu.Modules.Suppliers.Infrastructure.Suppliers;
using TikRandevu.Modules.Suppliers.Presentation.SupplierProvisions.PublicApi;
using TikRandevu.Modules.Suppliers.Presentation.SupplierRezervations.Consumers;
using TikRandevu.Modules.Suppliers.Presentation.Suppliers.SupplierApi;
using TikRandevu.Modules.Suppliers.PublicAPI.SupplierProvisions;
using TikRandevu.Modules.Suppliers.PublicAPI.Suppliers;
using TikRandevu.Shared.Infrastructure.Interceptors;

namespace TikRandevu.Modules.Suppliers.Infrastructure;

public static class SuppliersRegistrar
{
    public static IServiceCollection RegisterSuppliersModule(
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
        services.AddDbContext<SuppliersDbContext>(
            (sp, opt) =>
                opt.UseNpgsql(
                        dbConnectionString!,
                        builder => builder.MigrationsHistoryTable("Migrations", "Suppliers"))
                    .AddInterceptors(
                        sp.GetRequiredService<PublishDomainEventInterceptor>())
        );


        services.AddScoped<IUnitOfWork>(sp =>
            sp.GetRequiredService<SuppliersDbContext>()
        );


        services.AddScoped<ISupplierRepository, SupplierRepository>();
        services.AddScoped<ISupplierProvisionRepository, SupplierProvisionRepository>();
        services.AddScoped<ISupplierRezervationRepository, SupplierRezervationsRepository>();
        services.AddScoped<ISupplierApi, SupplierApi>();
        services.AddScoped<ISupplierProvisionsApi, SupplierProvisionsApi>();

        return services;
    }
    
    public static void ConfigureIntegrationEventConsumers(
        IRegistrationConfigurator registrationConfigurator
    )
    {
        registrationConfigurator.AddConsumer<RezervationPaidIntegrationEventConsumer>(); 
    }
}