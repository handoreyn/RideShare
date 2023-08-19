using RideShare.Domain.Common;

namespace RideShare.Domain.Entities;

/// <summary>
/// Defines <c>TravelPlan</c> entity.
/// </summary>
public sealed class TravelPlan : EntityBase
{
    public string Username { get; set; }
    public int SeatCount { get; set; }
    public string DepartureCity { get; set; }
    public string DestinationCity { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public DateTime TravelDateTime { get; set; }
}