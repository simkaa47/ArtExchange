using System.Data.Common;
using ArtExchange.Modules.ArtMeetings.Application.Abstractions.Data;
using ArtExchange.Modules.ArtMeetings.Domain.Meetings;
using ArtExchange.Modules.ArtMeetings.Infrastructure.DataAccess;
using ArtExchange.Modules.ArtMeetings.Infrastructure.DataAccess.Data;
using ArtExchange.Modules.ArtMeetings.Presentation.Meetings;
using FluentValidation;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;

namespace ArtExchange.Modules.ArtMeetings.Infrastructure;

public static class MeetingsModule
{
    public static void MapMeetingsModule(this IEndpointRouteBuilder app)
    {
        MeetingsEndpoints.MapMeetingsEndpoints(app);
    }

    public static IServiceCollection AddMeetingsModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Application.AssemblyReference.CurrentAssembly);
        });

        services.AddValidatorsFromAssembly(Application.AssemblyReference.CurrentAssembly, includeInternalTypes: true);

        services.AddInfrastructure(configuration);
        return services;
    }

    private static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string? host = configuration["DB_HOST"];
        string? port = configuration["DB_PORT"];
        string? database = configuration["DB_NAME"];
        string? user = configuration["DB_USER"];
        string? password = configuration["DB_PASSWORD"];
        string connectionString = $"Host={host};Port={port};Database={database};Username={user};Password={password}";
        DbDataSource source = new NpgsqlDataSourceBuilder(connectionString).Build();
        services.TryAddSingleton(source);

        services.AddDbContext<MeetingsDbContext>(options =>
        {
            options.UseNpgsql(connectionString, npqBuilder =>
            {
                npqBuilder.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Meetings);
            });
        });

        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
        services.AddScoped<IMeetingsQueryRepository, MeetingsQueryRepository>();
        services.AddScoped<IMeetingsRepository, MeetingsRepository>();
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<MeetingsDbContext>());

        return services;
    }
}
