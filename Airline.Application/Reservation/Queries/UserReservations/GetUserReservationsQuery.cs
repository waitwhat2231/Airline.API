﻿using Airline.Application.Reservation.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Reservation.Queries.UserReservations
{
    public class GetUserReservationsQuery : IRequest<IEnumerable<ReservationDto>>
    {
    }
}
