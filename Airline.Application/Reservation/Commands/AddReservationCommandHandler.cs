using Airline.Domain.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Reservation.Commands
{
    public class AddReservationCommandHandler(IMapper mapper ,
        IReservationRepository repository,
        IFlightRepository flightRepository) : IRequestHandler<AddReservationCommand, int>
    {
        public async Task<int> Handle(AddReservationCommand request, CancellationToken cancellationToken)
        {
            var flight = await flightRepository.GetFlight(request.FlightId);
            if(flight == null)
            {
                return -1;
            }
            var reservation = mapper.Map<Domain.Entities.ReservationEntities.Reservation>(request);
            reservation.PaymentStatus = false;
           var Id = await repository.AddReservation(reservation);
            return Id;
        }
    }
}
