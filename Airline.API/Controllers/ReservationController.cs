using Airline.Application.Reservation.Commands;
using Airline.Application.Reservation.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Airline.API.Controllers
{
    [ApiController]
    public class ReservationController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        [Authorize]
        [Route("api/flight/{Id}/Reservation")]
        public async Task<ActionResult>AddReservation(int Id,AddReservationCommand request)
        {
            request.FlightId = Id;
            var reservationId = await mediator.Send(request);
            return CreatedAtAction(nameof(GetReservation),new { reservationId },null);
        }
        [HttpGet]
        [Route("api/Reservation/{reservationId}")]
        public async Task<ActionResult>GetReservation(int reservationId)
        {
            var result = await mediator.Send(new GetReservationQuery(reservationId));
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
