using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Reservation.Commands
{
    public class AddReservationCommand : IRequest<int>
    {
        public int FlightId { get; set; }
        public string PassengerId { get; set; } = default!;
    }
}
