using Airline.Application.Airline.Commands;
using Airline.Application.Airline.Dtos;
using Airline.Application.Airline.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Airline.API.Controllers
{
    [ApiController]
    public class AirlineController(IMediator mediator) : ControllerBase
    {
        
        [HttpPost("/api/airline")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult>AddAirline(AddAirlineCommand command)
        {
            var Id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetAirline),new {Id},null);
        }
        [HttpGet("/api/airline/{Id}")]
        public async Task<ActionResult> GetAirline([FromRoute]int Id)
        {
            var request = new GetAirlineQuery(Id);
            var airline= await mediator.Send(request);
            return Ok(airline);
        }
    }
}
