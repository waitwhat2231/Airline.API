using Airline.Application.Users;
using Airline.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Payment.Commands
{
    internal class AddPaymentCommandHandler(IReservationRepository reservationRepository,
        IUserContext userContext) : IRequestHandler<AddPaymentCommand, int>
    {
        public async Task<int> Handle(AddPaymentCommand request, CancellationToken cancellationToken)
        {
            var userId = userContext.GetCurrentUser().Id;
            var result = await reservationRepository.AddPaymentToReservation(request.ReservationId,userId);
            return result;
           
        }
    }
}
