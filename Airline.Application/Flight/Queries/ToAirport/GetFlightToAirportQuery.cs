using Airline.Application.Flight.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Flight.Queries.ToAirport
{
    public class GetFlightToAirportQuery(int Id) : IRequest<IEnumerable<FlightToAirportDto>>
    {
        public int AirportId { get; set; } = Id;
    }
}
