using Airline.Application.Reservation.DTO;
using Airline.Application.Users;
using Airline.Domain.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Reservation.Queries.UserReservations
{
    internal class GetUserReservationsQueryHandler(IUserContext userContext,
        IReservationRepository reservationRepository
        ,IMapper mapper) : IRequestHandler<GetUserReservationsQuery, IEnumerable<ReservationDto>>
    {
        public async Task<IEnumerable<ReservationDto>> Handle(GetUserReservationsQuery request, CancellationToken cancellationToken)
        {
            var userId = userContext.GetCurrentUser().Id;
            var reservations = await reservationRepository.GetUserReservations(userId);
            var result = mapper.Map<IEnumerable<ReservationDto>>(reservations);
            return result;
        }
    }
}
