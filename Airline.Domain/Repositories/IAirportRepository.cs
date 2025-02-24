using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Domain.Repositories
{
    public interface IAirportRepository
    {
        public Task<int> Add(Domain.Entities.Airport entity);

        public Task<Domain.Entities.Airport?> GetById(int Id);

        public Task Delete(int Id);
        public Task Update(int Id, Domain.Entities.Airport entity);
    }
}
