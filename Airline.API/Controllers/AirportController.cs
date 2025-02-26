using Airline.Application.Airport.Commands;
using Airline.Application.Airport.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Airline.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AirportController (IMediator mediator): ControllerBase
    {
        [HttpPost]
        [Authorize(Roles ="Administrator")]
        public async Task<ActionResult> AddAirport([FromBody]AddAirportCommand request)
        {
            var Id= await mediator.Send(request);
            return CreatedAtAction(nameof(GetAirport), new { Id }, null);
        }
        [HttpGet]
        [Route("{Id}")]
        public async Task<ActionResult>GetAirport(int Id)
        {
            var request = new GetAirportQuery(Id);
            var result = await mediator.Send(request);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }

    }
}
