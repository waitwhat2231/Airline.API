using Airline.Application.Flight.DTO;
using Airline.Domain.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Flight.Queries.ToAirport
{
    public class GetFlightToAirportQueryHandler(IMapper mapper,
       IFlightRepository flightRepository) : IRequestHandler<GetFlightToAirportQuery, IEnumerable<FlightToAirportDto>>
    {
        public async Task<IEnumerable<FlightToAirportDto>> Handle(GetFlightToAirportQuery request, CancellationToken cancellationToken)
        {
            var flights = await flightRepository.GetFlightsToAirport(request.AirportId);
            var result = mapper.Map<IEnumerable<FlightToAirportDto>>(flights);
            return result;
        }
    }
}
