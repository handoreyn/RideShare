using RideShare.Domain.Abstractions;
using RideShare.Domain.Common;
using RideShare.Domain.ValueObjects;

namespace RideShare.Domain.Entities;

/// <summary>
/// Defines <c>TravelPlan</c> entity.
/// </summary>
public sealed class TravelPlan : EntityBase, IAggregateRoot
{
    public int SeatCount { get; set; }
    public bool IsActive { get; set; }
    public string Username { get; set; }
    public string Description { get; set; }
    public DateTime DepartureDateTime { get; set; }
    public TravelPlanRoute TravelPlanRoute { get; set; }
}
