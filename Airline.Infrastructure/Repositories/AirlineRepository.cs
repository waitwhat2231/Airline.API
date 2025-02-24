using Airline.Domain.Entities;
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
    public class AirlineRepository(AirlineDbContext context) : IAirlineRepository
    {
       public async Task<int> Add(Domain.Entities.Airline entity)
        {
            entity.AdminId = "ASdasd";
           context.Airlines.Add(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public Task DeleteAirline(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.Entities.Airline?> GetById(int id)
        {
            var airline = await context.Airlines.Include(ai => ai.Flights)
                .FirstOrDefaultAsync(ai => ai.Id == id);
                
            if (airline == null)
            {
                return null;
            }
            return airline;
        }
        

    }
}
