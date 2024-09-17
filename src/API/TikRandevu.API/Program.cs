using Serilog;
using TikRandevu.API.Middlewares;
using TikRandevu.Shared.Application;
using TikRandevu.Shared.Infrastructure;
using TikRandevu.Shared.Presentation;

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseSerilog(((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
}));

var services = builder.Services;



services.ApplySharedApplicationServices([]);

services.ApplySharedInfrastructureServices(
    configuration: builder.Configuration,
    moduleConfigureConsumers: []
);

services.AddEndPoints([]);

services.AddExceptionHandler<UnhandledExceptionHandlingMiddleware>();
services.AddProblemDetails();

var app = builder.Build();

app.MapEndPoints();

app.UseExceptionHandler();
app.UseSerilogRequestLogging();

app.Run();