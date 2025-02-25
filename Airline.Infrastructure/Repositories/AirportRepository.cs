using Airline.Domain.Entities;
using Airline.Domain.Exceptions;
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
    public class AirportRepository(AirlineDbContext context) : IAirportRepository
    {
        public async Task<int> Add(Airport entity)
        {
            await context.Airports.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Delete(int Id)
        {
            var airport = await context.Airports.FirstOrDefaultAsync(ai => ai.Id == Id) ?? throw new Domain.Exceptions.NotFoundException("Doesn't Exist");
            context.Airports.Remove(airport);
            await context.SaveChangesAsync();
        }

        public async Task<Airport?> GetById(int Id)
        {
            var airport = await context.Airports.Include(a => a.FlightsFrom).FirstOrDefaultAsync(a => a.Id == Id);
                if (airport == null)
            {
                return null;
            }
            return airport;
        }

        public async Task Update(int id, Domain.Entities.Airport entity)
        {
            var airline = await context.Airports.FirstOrDefaultAsync(ai => ai.Id == id) ?? throw new Domain.Exceptions.NotFoundException("Doesn't Exist");
            entity.Id = id;
            context.Airports.Update(entity);
            await context.SaveChangesAsync();

        }

    }
}
