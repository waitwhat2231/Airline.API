using Airline.Application.User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Reservation.DTO
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public bool PaymentStatus { get; set; } = false;
        public UserInfoDTO Passenger { get; set; } = default!;

    }
}
