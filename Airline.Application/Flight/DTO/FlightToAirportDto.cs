using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Flight.DTO
{
    public class FlightToAirportDto
    {
        public int Id { get; set; }
        public int AirlineId { get; set; }
        public int FromAirportId { get; set; }
        public int ToAirportId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DepartureTime { get; set; }
        public int ExpectedHoursFlightTime { get; set; }
        public int AvailableSeats { get; set; }
        public int Cost { get; set; } = 0;
    }
}
