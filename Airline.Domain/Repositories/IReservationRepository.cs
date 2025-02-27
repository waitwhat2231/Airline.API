using Airline.Domain.Entities.ReservationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Domain.Repositories
{
    public interface IReservationRepository
    {
        public Task<int> AddReservation(Reservation reservation);
        public Task ChangePaymentStatus(int id, bool status);
        public Task DelteReservation(int id);
        public Task<Domain.Entities.ReservationEntities.Reservation?> GetReservation(int Id);
        public Task<IEnumerable<Domain.Entities.ReservationEntities.Reservation>> GetUserReservations(string UserId);
        public  Task<IEnumerable<Domain.Entities.ReservationEntities.Reservation>> GetFlightReservations(int FlightId);
    }
}
