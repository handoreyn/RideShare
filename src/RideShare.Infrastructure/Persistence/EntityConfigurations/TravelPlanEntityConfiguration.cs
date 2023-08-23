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

        builder.Property(p => p.IsActive).IsRequired();
        builder.Property(p => p.SeatCount).IsRequired();
        builder.OwnsOne(p => p.TravelPlanRoute, p =>
        {
            p.Property(pp => pp.DestinationCity)
                .HasColumnName("TravelPlanRoute_DestinationCity");
            p.Property(pp => pp.DepartureCity)
                .HasColumnName("TravelRoute_DepartureCity");
        });

    }
}