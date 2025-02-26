using Airline.Application.Airline.Commands.Delete;
using Airline.Application.Airline.Commands.Update;
using Airline.Application.Users;
using Airline.Domain.Exceptions;
using Airline.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Airline.Commands.Behaviour
{
    public class AirlineCommandBehaviour<TRequest, TResponse> (IUserContext userContext,
        IAirlineRepository airlineRepository ): IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            int airlineId = 0;
            if (!userContext.GetCurrentUser().Roles.Contains("Administrator"))
            {
                if(request is DeleteAirlineCommand deleteAirlineCommand)
                {
                    airlineId = deleteAirlineCommand.Id;
                }
                else if(request is UpdateAirlineCommand updateAirlineCommand)
                {
                    airlineId = updateAirlineCommand.Id;
                }
                if(airlineId != 0)
                {
                    var userId = userContext.GetCurrentUser()?.Id;
                    var airline = await airlineRepository.GetById(airlineId);
                    if(airline is null)
                    {
                        throw new Domain.Exceptions.NotFoundException("AirlineNotFound");
                    }
                    if (airline.ManagerID != userId)
                    {
                        throw new OwnershipException("You do not own this airline");
                    }
                }
            }
            return await next();
        }
    }
}
