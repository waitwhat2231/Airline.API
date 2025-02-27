using Airline.Application.Flight.DTO;
using Airline.Domain.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Flight.Queries.FromAirport
{
    public class GetFlightFromAirportQueryHandler(IMapper mapper,
       IFlightRepository flightRepository ) : IRequestHandler<GetFlightFromAirportQuery, IEnumerable<FlightFromAirportDto>>
    {
        public async Task<IEnumerable<FlightFromAirportDto>> Handle(GetFlightFromAirportQuery request, CancellationToken cancellationToken)
        {
            var flights = await flightRepository.GetFlightsFromAirport(request.AirportId);
            var result = mapper.Map<IEnumerable<FlightFromAirportDto>>(flights);
            return result;
        }
    }
}
