using Airline.Application.Users;
using Airline.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Flight.Commands.Behaviour
{
    public class FlightCommandBehaviour<TRequest, TResponse>(IAirportRepository airportRepository,
        IAirlineRepository airlineRepository,
        IUserContext userContext) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            bool allExists = true;
            if(request is AddFlightCommand addFlightCommand)
            {       
                var airportFrom = await airportRepository.GetById(addFlightCommand.FromAirportId);
                var airportTo = await airportRepository.GetById(addFlightCommand.ToAirportId);
                var airline = await airlineRepository.GetById(addFlightCommand.AirlineId);
                if(airportFrom == null || airportTo == null) 
                {
                    allExists = false;
                }
                if(airline is null) 
                {
                    allExists = false;
                }
                if (!allExists)
                {
                    throw new Domain.Exceptions.NotFoundException("something here doesn't exist,information is missing");
                }
                var userId = userContext.GetCurrentUser().Id;
                if(airline.ManagerID != userId)
                {
                    throw new Domain.Exceptions.OwnershipException("you're not the owner of this airline");

                }    
            }
            return await next();
        }
    }
}
