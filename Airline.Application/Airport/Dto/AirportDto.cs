using Airline.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Airport.Dto
{
    public class AirportDto
    {
        public string Name { get; set; } = default!;
        public string Location { get; set; } = default!;
        public IEnumerable<Domain.Entities.Flight> FlightsFrom = [];
        public IEnumerable<Domain.Entities.Flight> FlightsTo = [];
    }
}
