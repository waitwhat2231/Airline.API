using Airline.Domain.Entities;
using Airline.Domain.Entities._ٌReservationEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Infrastructure.Persistence
{
    public class AirlineDbContext(DbContextOptions<AirlineDbContext> options) : IdentityDbContext<User>(options)
    {
        internal DbSet<Airline.Domain.Entities.Airline> Airlines { get; set; }
        internal DbSet<Airport> Airports { get; set; }
        internal DbSet<Flight> Flights { get; set; }
        internal DbSet<Payment> Payments {get; set;}
        internal DbSet<Reservation> Reservations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Flight>(entity =>
            {
                entity.HasOne(f => f.Airline)
                .WithMany(a => a.Flights)
                .HasForeignKey(f => f.AirlineId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(f => f.FromAirport)
                .WithMany(ai => ai.FlightsFrom)
                .HasForeignKey(f => f.FromAirportId)
                .OnDelete(DeleteBehavior.NoAction); 

                entity.HasOne(f => f.ToAirport)
                .WithMany(ai => ai.FlightsTo)
                .HasForeignKey(f => f.ToAirportId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasMany(f => f.Reservations)
                .WithOne(r => r.PayedForFlight)
                .HasForeignKey(r => r.FlightId)
                .OnDelete(DeleteBehavior.Cascade);
            }
            );
            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasMany(r => r.PaymentRecord)
                .WithOne(p => p.Reservation)
                .HasForeignKey(p => p.ReservationId)
                .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(r => r.Passenger)
                .WithMany(u => u.reservations)
                .HasForeignKey(r => r.PassengerId);
            }
            );
                

        }
    }
}
