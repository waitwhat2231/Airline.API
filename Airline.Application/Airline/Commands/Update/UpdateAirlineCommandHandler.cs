using Airline.Domain.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Airline.Commands.Update
{
    internal class UpdateAirlineCommandHandler(IAirlineRepository repository,
        IMapper mapper) : IRequestHandler<UpdateAirlineCommand,Unit>
    {
        public async Task<Unit> Handle(UpdateAirlineCommand request, CancellationToken cancellationToken)
        {
            var airline = mapper.Map<Domain.Entities.Airline>(request);
            await repository.UpdateAirline(request.Id, airline);
            return Unit.Value;
        }
    }
}
