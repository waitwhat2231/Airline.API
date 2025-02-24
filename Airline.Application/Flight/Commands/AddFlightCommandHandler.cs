using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Flight.Commands
{
    internal class AddFlightCommandHandler() : IRequestHandler<AddFlightCommand, int>
    {
        public Task<int> Handle(AddFlightCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
