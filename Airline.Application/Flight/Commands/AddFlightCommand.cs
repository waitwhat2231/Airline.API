using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Flight.Commands
{
    public class AddFlightCommand : IRequest<int>
    {
        
        
        public int AirlineId { get; set; }
        public int FromAirportId { get; set; }
        public int ToAirportId { get; set; }
        public DateTime DepartureTime { get; set; }
        public int ExpectedHoursFlightTime { get; set; }
        public int AvailableSeats { get; set; }
    }
}
