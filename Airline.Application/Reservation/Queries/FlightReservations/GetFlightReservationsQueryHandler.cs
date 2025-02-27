using Airline.Application.Reservation.DTO;
using Airline.Domain.Entities;
using Airline.Domain.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Reservation.Queries.FlightReservations
{
    internal class GetFlightReservationsQueryHandler(IMapper mapper , IReservationRepository reservationRepository) : IRequestHandler<GetFlightReservationsQuery, IEnumerable<ReservationDto>>
    {
        public async Task<IEnumerable<ReservationDto>> Handle(GetFlightReservationsQuery request, CancellationToken cancellationToken)
        {
            var reservations = await reservationRepository.GetFlightReservations(request.FlightId);
            var result = mapper.Map<IEnumerable<ReservationDto>>(reservations);
            return result;
        }
    }
}
