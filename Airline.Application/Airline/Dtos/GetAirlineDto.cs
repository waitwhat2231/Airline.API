using Airline.Application.User.DTO;
using Airline.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Airline.Dtos
{
    public class GetAirlineDto
    {
        public string Name { get; set; } = default!;
        public string ContactNumber { get; set; } = default!;
        public UserInfoDTO Manager { get; set; } = default!;
        public IEnumerable<Domain.Entities.Flight> Flights = [];
    }
}
