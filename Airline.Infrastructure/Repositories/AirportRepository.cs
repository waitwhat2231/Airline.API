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

        public Task Delete(int Id)
        {
            throw new NotImplementedException();
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

        public async Task Update(int Id, Airport entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
        }

    }
}
