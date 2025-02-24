using Airline.Domain.Entities;
using Airline.Domain.Entities._ٌReservationEntities;
using Airline.Domain.Repositories;
using Airline.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Infrastructure.Repositories
{
    public class FlightRepository(AirlineDbContext context) : IFlightRepository
    {
        public async Task<int> Add(Flight flight)
        {
            context.Flights.Add(flight);
            await context.SaveChangesAsync();
            return flight.Id;
        }

        public async Task Delete(int Id)
        {
            var flight = await context.Flights.FirstOrDefaultAsync(fl => fl.Id == Id) ?? throw new Domain.Exceptions.NotFoundException("Flight not found to be deleted");

            context.Flights.Remove(flight);
            await context.SaveChangesAsync();
        }

        public async Task<Flight?> GetFlight(int Id)
        {
            var flight = await context.Flights
                .Include(fl=>fl.Reservations)
                .FirstOrDefaultAsync(f => f.Id == Id);
            return flight;
        }

        public Task Update(Flight flight)
        {
            throw new NotImplementedException();
        }
    }
}
