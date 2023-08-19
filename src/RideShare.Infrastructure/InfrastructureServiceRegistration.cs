using Microsoft.Extensions.DependencyInjection;
using RideShare.Domain.Abstractions.Repositories;
using RideShare.Infrastructure.Repositories;

namespace RideShare.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ITravelPlanRepository, TravelPlanRepository>();
    }
}