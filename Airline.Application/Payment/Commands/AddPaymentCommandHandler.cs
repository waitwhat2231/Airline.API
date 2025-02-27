using Airline.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Payment.Commands
{
    internal class AddPaymentCommandHandler(IReservationRepository reservationRepository) : IRequestHandler<AddPaymentCommand, int>
    {
        public async Task<int> Handle(AddPaymentCommand request, CancellationToken cancellationToken)
        {
            
            return -1;
        }
    }
}
