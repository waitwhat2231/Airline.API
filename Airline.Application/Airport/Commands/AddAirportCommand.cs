using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Airport.Commands
{
    public class AddAirportCommand : IRequest<int>
    { 
        public string Name { get; set; } = default!;
        public string Location { get; set; } = default!;
    }
}
