using AutoMapper;
using RideShare.Application.Features.TravelPlans.Commands.CreateTravelPlan;
using RideShare.Application.Features.TravelPlans.Queries.SearchTravelPlan;
using RideShare.Domain.Entities;

namespace RideShare.Application.Mappings;

public sealed class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<TravelPlan, CreateTravelPlanCommand>().ReverseMap();
        CreateMap<TravelPlan, SearchTravelPlanDto>().ReverseMap();
    }
}