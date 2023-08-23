using AutoMapper;
using RideShare.Application.Features.TravelPlans.Commands.CreateTravelPlan;
using RideShare.Application.Features.TravelPlans.Queries.SearchTravelPlan;
using RideShare.Domain.Entities;

namespace RideShare.Application.Mappings;

public sealed class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<TravelPlan, CreateTravelPlanCommand>()
            .AfterMap((src, dest) =>
            {
                dest.DepartureCity = src.TravelPlanRoute.DepartureCity;
                dest.DestinationCity = src.TravelPlanRoute.DestinationCity;
            })
        .ReverseMap()
            .AfterMap((src, dest) =>
            {
                dest.TravelPlanRoute = new Domain.ValueObjects.TravelPlanRoute(src.DepartureCity, src.DestinationCity);
            });

        CreateMap<TravelPlan, SearchTravelPlanDto>()
            .ReverseMap();
    }
}