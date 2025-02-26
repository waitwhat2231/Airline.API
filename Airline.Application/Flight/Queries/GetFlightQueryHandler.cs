using Airline.Application.Flight.DTO;
using Airline.Domain.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Flight.Queries
{
    public class GetFlightQueryHandler(IFlightRepository flightRepository,
        IMapper mapper) : IRequestHandler<GetFlightQuery, GetFlightDTO>
    {
        public async Task<GetFlightDTO> Handle(GetFlightQuery request, CancellationToken cancellationToken)
        {
            var flight = await flightRepository.GetFlight(request.Id);
            var result = mapper.Map<GetFlightDTO>(flight);
            return result;
        }
    }
}
