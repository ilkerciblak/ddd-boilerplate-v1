using TikRandevu.API.Middlewares;
using TikRandevu.Shared.Application;
using TikRandevu.Shared.Infrastructure;
using TikRandevu.Shared.Presentation;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;


services.ApplySharedApplicationServices([]);

services.ApplySharedInfrastructureServices(
    builder.Configuration
);

services.AddEndPoints([]);

services.AddExceptionHandler<UnhandledExceptionHandlingMiddleware>();
services.AddProblemDetails();

var app = builder.Build();

app.MapEndPoints();

app.UseExceptionHandler();

app.Run();