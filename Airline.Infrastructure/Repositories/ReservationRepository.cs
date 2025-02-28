using Airline.Domain.Entities;
using Airline.Domain.Entities.ReservationEntities;
using Airline.Domain.Repositories;
using Airline.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Infrastructure.Repositories
{
    public class ReservationRepository(AirlineDbContext context,IAccountRepository accountRepository) : IReservationRepository
    {
        public async Task<int> AddReservation(Reservation reservation)
        {
            
            context.Reservations.Add(reservation);
            var flight = await context.Flights.FindAsync(reservation.FlightId);
            flight.AvailableSeats = flight.AvailableSeats - 1;
             context.Flights.Update(flight);
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

        public async Task<IEnumerable<Reservation>> GetUserReservations(string UserId)
        {
            var reservations = await context.Reservations.Where(res => res.PassengerId == UserId).ToListAsync();
            return reservations;
        }
        public async Task<IEnumerable<Reservation>> GetFlightReservations(int FlightId)
        {
            var reservations = await context.Reservations
                .Include(res => res.Passenger)
                .Where(res => res.FlightId == FlightId)
                .ToListAsync();
            return reservations;
        }

        public async Task<int> AddPaymentToReservation(int reservationId, string userId)
        {
            var reservation = await context.Reservations.FindAsync(reservationId);
            if(reservation == null)
            {
                throw new Domain.Exceptions.NotFoundException("Reservation does not exist");
            }
            var payment = new Payment
            {
                ReservationId = reservationId
            };
            var user = await accountRepository.GetUserAsync(userId);
            var flight = await context.Flights.FindAsync(reservation.FlightId);
            await accountRepository.FillWallet(user.Email, (-1 * flight.Cost));
            context.Payments.Add(payment);
            await context.SaveChangesAsync();
            return payment.Id;
        }
    }
}
