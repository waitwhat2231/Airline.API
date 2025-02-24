using Airline.Application.Airport.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Airport.Queries
{
    public class GetAirportQuery(int Id) : IRequest<AirportDto>
    {
        public int Id { get; set; } = Id;
    }
}
