using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Flight.Queries
{
    public class GetFlightQuery(int Id)
    {
        public int Id { get; set; } = Id;
    }
}
