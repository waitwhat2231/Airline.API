using Airline.Application.Reservation.DTO;
using Airline.Domain.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Reservation.Queries
{
    internal class GetReservationQueryHandler(IReservationRepository reservationRepository,
        IMapper mapper) : IRequestHandler<GetReservationQuery, ReservationDto>
    {
        public async Task<ReservationDto> Handle(GetReservationQuery request, CancellationToken cancellationToken)
        {
            var reservation = await reservationRepository.GetReservation(request.Id);
            var result = mapper.Map<ReservationDto>(reservation);
            return result;
        }
    }
}
