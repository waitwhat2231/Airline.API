using Airline.Application.Users;
using Airline.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Payment.Commands.Behaviour
{
    public class PaymentCommandBehaviour<TRequest, TResponse>(IUserContext userContext,
        IReservationRepository reservationRepository,
        IFlightRepository flightRepository,
        IAccountRepository accountRepository) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(request is AddPaymentCommand paymentCommand)
            {
                var userId = userContext.GetCurrentUser()?.Id;
                var reservation = await reservationRepository.GetReservation(paymentCommand.ReservationId);
                if(reservation is null)
                {
                    throw new Domain.Exceptions.NotFoundException("Reservation doesn't exist");
                }
                if(userId != reservation.PassengerId) 
                {
                    throw new Domain.Exceptions.OwnershipException("This isn't your reservation");
                }
                var flight = await flightRepository.GetFlight(reservation.FlightId);
                var user = await accountRepository.GetUserAsync(userId);
                if (user.Wallet < flight.Cost)
                {
                    throw new Exception("not enough money");
                }
            }
            return await next();
        }
    }
}
