using Airline.Application.Airline.Commands.Add;
using Airline.Application.Airline.Commands.Delete;
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
        [HttpDelete("{Id}")]
        [Authorize]
        public async Task<ActionResult> DeleteAirline([FromRoute] int Id)
        {
            await mediator.Send(new DeleteAirlineCommand(Id));
            return NoContent();
        }
    }
}
