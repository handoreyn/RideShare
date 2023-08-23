using RideShare.Domain.Common;

namespace RideShare.Domain.ValueObjects;

/// <summary>
/// Defines <c>TravelPlanValueObject</c>
/// </summary>
/// <param name="DepartureCity">Represents start point of <c>TravelPlanRoute</c></param>
/// <param name="DestinationCity">Represents finish point of <c>TravelPlan</c></param>
public sealed class TravelPlanRoute : ValueObject
{
    public string DepartureCity { get; init; }
    public string DestinationCity { get; init; }

    public TravelPlanRoute(string departureCity, string destinationCity)
    {
        DepartureCity = departureCity;
        DestinationCity = destinationCity;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return DestinationCity;
        yield return DepartureCity;
    }
}