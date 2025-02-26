using Airline.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Domain.Repositories
{
    public interface IFlightRepository
    {
        public Task<int> Add(Flight flight);
        public Task<Flight?> GetFlight(int Id);
        public Task Update(Flight flight);
        public Task Delete(int Id);
        public Task<IEnumerable<Flight>> GetFlightsFromAirport(int airportId);
        public Task<IEnumerable<Flight>> GetFlightsToAirport(int airportId);
    }
}
