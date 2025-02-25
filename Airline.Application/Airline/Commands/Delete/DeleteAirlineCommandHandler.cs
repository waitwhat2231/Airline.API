﻿using Airline.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Airline.Commands.Delete
{
    internal class DeleteAirlineCommandHandler(IAirlineRepository repository) : IRequestHandler<DeleteAirlineCommand>
    {
        public async Task Handle(DeleteAirlineCommand request, CancellationToken cancellationToken)
        {
            await repository.DeleteAirline(request.Id);
        }
    }
}
