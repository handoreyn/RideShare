using Microsoft.EntityFrameworkCore;
using RideShare.Domain.Entities;

namespace RideShare.Infrastructure.Persistence;

public sealed class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
    {       
    }

    public DbSet<TravelPlan> TravelPlans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}