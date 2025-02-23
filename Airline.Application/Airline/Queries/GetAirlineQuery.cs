using Airline.Application.Airline.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Airline.Queries
{
    public class GetAirlineQuery(int Id) : IRequest<GetAirlineDto>
    {
        public int Id { get; set; } = Id;
    }
}
