using MediatR;
using Microsoft.AspNetCore.Mvc;
using RideShare.Application.Features.TravelPlans.Commands.CreateTravelPlan;
using RideShare.Application.Features.TravelPlans.Commands.JoinTravelPlan;
using RideShare.Application.Features.TravelPlans.Commands.UpdateTravelPlanStatus;
using RideShare.Application.Features.TravelPlans.Queries.FindTravelPlanById;
using RideShare.Application.Features.TravelPlans.Queries.SearchTravelPlan;

namespace RideShare.Api.Controllers;

[ApiController]
[Route("api/travel-plans")]
public class TravelPlanController : ControllerBase
{
    private readonly ISender _sender;

    public TravelPlanController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> AddTravelPlan(CreateTravelPlanCommand command, CancellationToken cancellationToken = default)
    {
        var result = await _sender.Send(command, cancellationToken);
        var resourceUrl = Url.ActionLink("GetById", "TravelPlan", new { id = result });
        return Created(resourceUrl, null);
    }

    [HttpGet("{id:int}", Name = "GetById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var query = new FindTravelPlanByIdQuery(id);
        var result = await _sender.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpGet("search/departure/{departureCity}/destionation/{destinationCity}")]
    [ProducesResponseType(typeof(List<SearchTravelPlanDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Search(string departureCity, string destinationCity, CancellationToken cancellationToken)
    {
        var searchTravelPlanQuery = new SearchTravelPlanQuery(departureCity, destinationCity);
        var result = await _sender.Send(searchTravelPlanQuery, cancellationToken);
        return Ok(result);
    }

    [HttpPut("{id}/join")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Join(int id, CancellationToken cancellationToken)
    {
        var command = new JoinTravelPlanCommand(id);
        await _sender.Send(command, cancellationToken);
        return NoContent();
    }

    [HttpPut("{id}/change/{status}")]
    public async Task<IActionResult> ChangeStatus(int id, bool status, CancellationToken cancellationToken)
    {
        var command = new UpdateTravelPlanStatusCommand(id, status);
        await _sender.Send(command, cancellationToken);
        return NoContent();
    }
}