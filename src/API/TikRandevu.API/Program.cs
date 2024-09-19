using Serilog;
using TikRandevu.API.Middlewares;
using TikRandevu.Modules.Provisions.Infrastructure;
using TikRandevu.Modules.Rezervations.Infrastructure;
using TikRandevu.Modules.Suppliers.Infrastructure;
using TikRandevu.Shared.Application;
using TikRandevu.Shared.Infrastructure;
using TikRandevu.Shared.Presentation;

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseSerilog(((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
}));

var services = builder.Services;



services.ApplySharedApplicationServices([   
    TikRandevu.Modules.Provisions.Application.AssemblyReference.Assembly,
    TikRandevu.Modules.Suppliers.Application.AssemblyReference.Assembly,
    TikRandevu.Modules.Rezervations.Application.AssemblyReference.Assembly,
]);

services.ApplySharedInfrastructureServices(
    configuration: builder.Configuration,
    moduleConfigureConsumers: [SuppliersRegistrar.ConfigureIntegrationEventConsumers]
);

services.AddEndPoints([
    TikRandevu.Modules.Provisions.Presentation.AssemblyReference.Assembly,
    TikRandevu.Modules.Suppliers.Presentation.AssemblyReference.Assembly,
    TikRandevu.Modules.Rezervations.Presentation.AssemblyReference.Assembly
]);



services.AddExceptionHandler<UnhandledExceptionHandlingMiddleware>();
services.AddProblemDetails();

services.RegisterProvisionsModule(builder.Configuration);
services.RegisterSuppliersModule(builder.Configuration);
services.RegisterRezervationsModule(builder.Configuration);

var app = builder.Build();

app.UseExceptionHandler();
app.UseSerilogRequestLogging();

app.MapEndPoints();




app.Run();