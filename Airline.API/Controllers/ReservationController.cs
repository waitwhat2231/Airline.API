using Airline.Application.Reservation.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Airline.API.Controllers
{
    [ApiController]
    public class ReservationController(IMediator mediator) : ControllerBase
    {
       /* [HttpPost]
        [Authorize]
        [Route("api/flight/{Id}/Reservation")]
        public async Task<ActionResult>AddReservation(int Id,AddReservationCommand request)
        {

            var reservationId = await mediator.Send(request);
            return CreatedAtAction();
        }
        [HttpGet]
        [Route("api/Reservation/{reservationId}")]
        public async Task<ActionResult>GetReservation(int reservationId)
        {
            await mediator.Send(new GetReser)
        }*/
    }
}
