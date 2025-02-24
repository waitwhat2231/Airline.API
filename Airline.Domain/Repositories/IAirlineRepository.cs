using Airline.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Domain.Repositories
{
    public interface IAirlineRepository
    {
        public Task<int> Add(Airline.Domain.Entities.Airline entity);
        public Task<Entities.Airline?> GetById(int id);
        public Task DeleteAirline(int id);
    }
}
