using Airline.Application.Flight.Commands;
using Airline.Application.Flight.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Airline.API.Controllers
{
    [ApiController]
    
    public class FlightController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        [Route("api/airline/{Id}/flight")]
        [Authorize(Roles ="AirlineManager")]
        public async Task<ActionResult>AddFlight(int Id,AddFlightCommand request)
        {
            request.AirlineId = Id;
            var flightId = await mediator.Send(request);
            return CreatedAtAction(nameof(GetFlight), new { flightId }, null);
        }
        [HttpGet]
        [Route("api/flight/{flightId}")]
        public async Task<ActionResult>GetFlight(int flightId)
        {
            var flight = await mediator.Send(new GetFlightQuery(flightId));
            if(flight == null)
            {
                return NotFound();
            }
            return Ok(flight);
        }

    }
}
