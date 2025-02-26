using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Airline.Commands.Delete
{
    public class DeleteAirlineCommand(int Id) : IRequest<Unit>
    {
        public int Id { get; set; } = Id;
    }
}
