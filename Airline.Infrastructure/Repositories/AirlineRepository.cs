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
            
           context.Airlines.Add(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteAirline(int id)
        {
            var airline = await context.Airlines.FirstOrDefaultAsync(ai => ai.Id == id) ?? throw new Domain.Exceptions.NotFoundException("AirlineDoesn't Exist");
            context.Airlines.Remove(airline);
            await context.SaveChangesAsync();
        }

        public async Task<Domain.Entities.Airline?> GetById(int id)
        {
            var airline = await context.Airlines
                .Include(ai => ai.Manager)
                .FirstOrDefaultAsync(ai => ai.Id == id);
                
                
            if (airline == null)
            {
                return null;
            }
            return airline;
        }

        public async Task UpdateAirline(int id, Domain.Entities.Airline newAirlineInfo)
        {
            var airline = await context.Airlines.FirstOrDefaultAsync(ai => ai.Id == id) ?? throw new Domain.Exceptions.NotFoundException("Doesn't Exist");
            newAirlineInfo.Id = id;
            context.Airlines.Update(newAirlineInfo);
            await context.SaveChangesAsync();

        }
    }
}
