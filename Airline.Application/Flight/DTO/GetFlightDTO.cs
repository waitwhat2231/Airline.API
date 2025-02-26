using Airline.Domain.Entities.ReservationEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Flight.DTO
{
    public class GetFlightDTO
    {
        public int Id { get; set; }
        public int AirlineId { get; set; }
        public int FromAirportId { get; set; }
        public int ToAirportId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DepartureTime { get; set; }
        public int ExpectedHoursFlightTime { get; set; }
        public int AvailableSeats { get; set; }
        public IEnumerable<Domain.Entities.ReservationEntities.Reservation> Reservations = [];
        public Domain.Entities.Airline Airline { get; set; } = default!;
        public Domain.Entities.Airport FromAirport { get; set; } = default!;
        public Domain.Entities.Airport ToAirport { get; set; } = default!;
    }
}
