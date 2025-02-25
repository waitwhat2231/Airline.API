using Airline.Application.Airline.Commands;
using Airline.Application.Airline.Dtos;
using Airline.Application.Airline.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Airline.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AirlineController(IMediator mediator) : ControllerBase
    {
        
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult>AddAirline(AddAirlineCommand command)
        {
            var Id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetAirline),new {Id},null);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult> GetAirline([FromRoute]int Id)
        {
            var request = new GetAirlineQuery(Id);
            var airline= await mediator.Send(request);
            return Ok(airline);
        }
    }
}
