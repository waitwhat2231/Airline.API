﻿using Airline.Domain.Entities._ٌReservationEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Domain.Entities
{
    public class Flight
    {
        public int Id { get; set; }
        [ForeignKey("Airline")]
        public int AirlineId { get; set; }
        public int FromAirportId { get; set; }
        public int ToAirportId { get; set; }
        public DateTime DepartureTime { get; set; }
        public int ExpectedHoursFlightTime { get; set; }
        public int AvailableSeats { get; set; }
        public IEnumerable<Reservation> Reservations = new List<Reservation>();
        public Airline Airline { get; set; } = default!;
        public Airport FromAirport { get; set; } = default!;
        public Airport ToAirport { get; set; } = default!;
    }
}
