﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Domain.Entities.ReservationEntities
{
    public class Payment
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public Reservation Reservation { get; set; } = default!;
    }
}
