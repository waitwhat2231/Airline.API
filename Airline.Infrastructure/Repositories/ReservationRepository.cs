using Airline.Domain.Entities.ReservationEntities;
using Airline.Domain.Repositories;
using Airline.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Infrastructure.Repositories
{
    public class ReservationRepository(AirlineDbContext context) : IReservationRepository
    {
        public async Task<int> AddReservation(Reservation reservation)
        {
            context.Reservations.Add(reservation);
            await context.SaveChangesAsync();
            return reservation.Id;
        }

        public async Task ChangePaymentStatus(int id, bool status)
        {
            var reservation = await context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                throw new Domain.Exceptions.NotFoundException("Reservation doesn't exist");

            }
            reservation.PaymentStatus = status;
            context.Update(reservation);
            await context.SaveChangesAsync();
        }

        public Task DelteReservation(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Reservation?> GetReservation(int Id)
        {
            var reservation = await context.Reservations
                .Include(res => res.Passenger)
                .FirstOrDefaultAsync(res=>res.Id==Id);
            if(reservation == null)
            {
                return null;
            }
            return reservation;
        }
        
    }
}
