using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        RegisterRepositories(services);
        RegisterServices(services);

        return services;
    }

    // These will grow so you can extract to a separate file
    // You do you, Boo
    private static void RegisterRepositories(IServiceCollection services)
    {
        services.AddTransient<IPlayerRepository, PlayerRepository>();
        services.AddTransient<ITeamRepository, TeamRepository>();
    }

    private static void RegisterServices(IServiceCollection services)
    {
        services.AddTransient<IPlayerService, PlayerService>();
        services.AddTransient<ITeamService, TeamService>();
    }
}