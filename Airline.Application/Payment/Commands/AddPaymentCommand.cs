using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Payment.Commands
{
    public class AddPaymentCommand : IRequest<int>
    {
        public string UserId { get; set; } = default!;
        public int ReservationId { get; set; }
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; } = DateTime.Now;
    }
}
