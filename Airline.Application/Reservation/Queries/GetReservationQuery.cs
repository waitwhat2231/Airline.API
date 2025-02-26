using Airline.Application.Reservation.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Reservation.Queries
{
    public class GetReservationQuery(int Id) : IRequest<ReservationDto>
    {
        public int Id { get; set; } = Id;
    }
}
