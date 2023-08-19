using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideShare.Domain.Entities;

namespace RideShare.Infrastructure.Persistence.EntityConfigurations;

public sealed class TravelPlanEntityConfiguration : IEntityTypeConfiguration<TravelPlan>
{
    public void Configure(EntityTypeBuilder<TravelPlan> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.CreatedAt)
            .HasDefaultValue(DateTime.Now);

        builder.Property(p => p.DepartureCity).IsRequired();
        builder.Property(p => p.DestinationCity).IsRequired();
        builder.Property(p => p.IsActive).IsRequired();
        builder.Property(p => p.SeatCount).IsRequired();

        builder.HasIndex(p => new { p.DepartureCity, p.DestinationCity }, "IX_TravelPlan_DepartureCity_DestinationCity");
    }
}