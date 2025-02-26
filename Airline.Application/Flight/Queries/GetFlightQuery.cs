using Airline.Application.Flight.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Flight.Queries
{
    public class GetFlightQuery(int Id) : IRequest<GetFlightDTO>
    {
        public int Id { get; set; } = Id;
    }
}
