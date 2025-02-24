using Airline.Domain.Entities;
using Airline.Domain.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Airport.Commands
{
    public class AddAirportCommandHandler(IAirportRepository repository,
        IMapper mapper) : IRequestHandler<AddAirportCommand, int>
    {
        public async Task<int> Handle(AddAirportCommand request, CancellationToken cancellationToken)
        {
            var airport = mapper.Map<Domain.Entities.Airport>(request);
            var Id = await repository.Add(airport);
            return Id;
        }
    }
}
