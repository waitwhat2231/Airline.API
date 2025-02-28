using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Payment.Commands
{
    public class AddPaymentCommand(int ReservationId) : IRequest<int>
    {
        public int ReservationId { get; set; } = ReservationId;
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; } = DateTime.Now;
    }
}
