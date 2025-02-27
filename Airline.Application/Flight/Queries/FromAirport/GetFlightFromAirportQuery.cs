using Airline.Application.Flight.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Flight.Queries.FromAirport
{
    public class GetFlightFromAirportQuery(int AirportId) : IRequest<IEnumerable<FlightFromAirportDto>>
    {
        public int AirportId { get; set; } = AirportId;
    }
}
