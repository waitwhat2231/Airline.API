using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Domain.Entities.ReservationEntities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public string PassengerId { get; set; } = default!;
        public bool PaymentStatus { get; set; } = false;
        public int Cost { get; set; } = 0;
        public Flight PayedForFlight { get; set; } = default!;
        public User Passenger { get; set; } = default!;
       

        public IEnumerable<Payment>? PaymentRecord { get; set; }
    }
}
