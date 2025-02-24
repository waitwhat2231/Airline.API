using Airline.Application.Airport.Dto;
using Airline.Domain.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Airport.Queries
{
    internal class GetAirportQueryHandler(IAirportRepository repository,IMapper mapper) : IRequestHandler<GetAirportQuery, AirportDto>
    {
        public async Task<AirportDto> Handle(GetAirportQuery request, CancellationToken cancellationToken)
        {
            var airport = await repository.GetById(request.Id);
            var result = mapper.Map<AirportDto>(airport);
            return result;
        }
    }
}
