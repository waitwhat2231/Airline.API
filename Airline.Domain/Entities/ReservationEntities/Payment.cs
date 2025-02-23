using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Domain.Entities._ٌReservationEntities
{
    public class Payment
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public int Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public Reservation Reservation { get; set; } = default!;
    }
}
