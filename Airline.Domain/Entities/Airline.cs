using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Domain.Entities
{
    public class Airline
    {
        
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string ContactNumber { get; set; } = default!;

        public string ManagerID { get; set; } = default!;
        public Domain.Entities.User Manager { get; set; } = default!;
        public IEnumerable<Flight>? Flights { get; set; }

    }
}
