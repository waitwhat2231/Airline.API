using Airline.Domain.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Flight.Commands
{
    internal class AddFlightCommandHandler(IFlightRepository repository, IMapper mapper) : IRequestHandler<AddFlightCommand, int>
    {
        public async Task<int> Handle(AddFlightCommand request, CancellationToken cancellationToken)
        {
            var flight = mapper.Map<Domain.Entities.Flight>(request);
            var result = await repository.Add(flight);
            return result;
        }
    }
}
