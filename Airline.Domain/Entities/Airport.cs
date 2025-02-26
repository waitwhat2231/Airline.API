using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Domain.Entities
{
    public class Airport
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Location { get; set; } = default!;
        public IEnumerable<Flight>? FlightsFrom { get; set; }
        public IEnumerable<Flight>? FlightsTo { get; set; }
    }
}
