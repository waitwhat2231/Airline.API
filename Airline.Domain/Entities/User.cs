using Airline.Domain.Entities._ٌReservationEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Domain.Entities
{
    public class User:IdentityUser
    {
        public string PassportNumber { get; set; } = default!;
        public int Wallet { get; set; } = 0;
        public IEnumerable<Reservation> reservations = [];
    }
}
