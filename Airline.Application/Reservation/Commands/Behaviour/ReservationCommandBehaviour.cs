using Airline.Application.Reservation.Commands.Add;
using Airline.Application.Reservation.Queries.FlightReservations;
using Airline.Application.Users;
using Airline.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Reservation.Commands.Behaviour
{
    public class ReservationCommandBehaviour<TRequest, TResponse>(IFlightRepository flightRepository,
        IUserContext userContext,
        IAirlineRepository airlineRepository) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            
            if (request is AddReservationCommand reservationCommand)
            {
                var flight = await flightRepository.GetFlight(reservationCommand.FlightId);
                if(flight == null)
                {
                    throw new Domain.Exceptions.NotFoundException("Flight not found");
                }

                if (flight.AvailableSeats == 0)
                {
                    throw new Exception("no enough seats");
                }
                
            }
            if (request is GetFlightReservationsQuery getFlightReservationsQuery)
            {
                var flight = await flightRepository.GetFlight(getFlightReservationsQuery.FlightId);
                if (flight == null)
                {
                    throw new Domain.Exceptions.NotFoundException("Flight not found");
                }
                var userId = userContext.GetCurrentUser().Id;
                var flightAirline = await airlineRepository.GetById(flight.AirlineId);
                if(flightAirline == null || flightAirline.ManagerID != userId)
                {
                    throw new Domain.Exceptions.OwnershipException("You do not own this airline or it does not exist");
                }
            }
            return await next();
        }
    }
}
