using Airline.Application.Payment.Commands;
using Airline.Application.Reservation.Commands.Add;
using Airline.Application.Reservation.Queries;
using Airline.Application.Reservation.Queries.FlightReservations;
using Airline.Application.Reservation.Queries.UserReservations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Airline.API.Controllers
{
    [ApiController]
    public class ReservationController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        [Authorize]
        [Route("api/flight/{Id}/reservation")]
        public async Task<ActionResult>AddReservation(int Id,AddReservationCommand request)
        {
            request.FlightId = Id;
            var reservationId = await mediator.Send(request);
            if(reservationId == -1)
            {
                return BadRequest("Flight Does not Exist");
            }
            return CreatedAtAction(nameof(GetReservation),new { reservationId },null);
        }
        [HttpGet]
        [Route("api/reservation/{reservationId}")]
        public async Task<ActionResult>GetReservation(int reservationId)
        {
            var result = await mediator.Send(new GetReservationQuery(reservationId));
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("api/reservation/userReservations")]
        [Authorize]
        public async Task<ActionResult> GetUserReservations()
        {
            var result = await mediator.Send(new GetUserReservationsQuery());
            return Ok(result);
        }
        [HttpGet]
        [Route("api/reservation/flightReservations/{FlightId}")]
        [Authorize(Roles ="AirlineManager")]
        public async Task<ActionResult> GetFlightReservations([FromRoute] int FlightId)
        {
            var result = await mediator.Send(new GetFlightReservationsQuery(FlightId));
            return Ok(result);
        }
        [HttpPost]
        [Route("api/reservation/{reservationId}/payment")]
        [Authorize]
        public async Task<ActionResult> AddPaymentToReservation(int reservationId)
        {
            var Id = await mediator.Send(new AddPaymentCommand(reservationId));
            if(Id == -1)
            {
                return BadRequest();
            }
            return Created();
        }
    }
}
