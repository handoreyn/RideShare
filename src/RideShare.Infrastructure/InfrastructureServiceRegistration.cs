using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RideShare.Domain.Abstractions.Repositories;
using RideShare.Infrastructure.Persistence;
using RideShare.Infrastructure.Repositories;

namespace RideShare.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(configuration.GetConnectionString("RideShareDbContext")));
        services.AddScoped<ITravelPlanRepository, TravelPlanRepository>();
    }
}