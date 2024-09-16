using TikRandevu.Shared.Application;
using TikRandevu.Shared.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;


services.ApplySharedApplicationServices([]);

services.ApplySharedInfrastructureServices();


var app = builder.Build();


app.Run();