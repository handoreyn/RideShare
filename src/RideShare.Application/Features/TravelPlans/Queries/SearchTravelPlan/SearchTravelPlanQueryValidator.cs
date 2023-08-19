using System.Data;
using FluentValidation;

namespace RideShare.Application.Features.TravelPlans.Queries.SearchTravelPlan;

public sealed class SearchTravelPlanQueryValidator : AbstractValidator<SearchTravelPlanQuery>
{
    public SearchTravelPlanQueryValidator()
    {
        RuleFor(r=>r.DepartureCity)
            .NotEmpty()
            .WithMessage("DepartureCity can not be empty.");
    
        RuleFor(r=>r.DestinationCity)
            .NotEmpty()
            .WithMessage("DestinationCity can not be empty. ");
    }
}