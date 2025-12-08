using ArtExchange.API.Extensions;
using ArtExchange.Modules.ArtMeetings.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddMeetingsModule(builder.Configuration);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MigrateDatabases();
}

app.MapMeetingsModule();

app.MigrateDatabases();

app.Run();
