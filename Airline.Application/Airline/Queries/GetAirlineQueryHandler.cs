using Airline.Application.Airline.Dtos;
using Airline.Domain.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Airline.Queries
{
    public class GetAirlineQueryHandler(IAirlineRepository repository,IMapper mapper) : IRequestHandler<GetAirlineQuery, GetAirlineDto>
    {
        public async Task<GetAirlineDto> Handle(GetAirlineQuery request, CancellationToken cancellationToken)
        {
            var airline =await repository.GetById(request.Id);
            var result = mapper.Map<GetAirlineDto>(airline);
            return result;
        }
    }
}
