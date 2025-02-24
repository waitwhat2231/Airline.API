using Airline.Application.Users;
using Airline.Domain.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Airline.Commands
{
    public class AddAirlineCommandHandler(IAirlineRepository airlineRepository,
        IMapper mapper,
        IUserContext userContext) : IRequestHandler<AddAirlineCommand,int>
    {
        public async Task<int> Handle(AddAirlineCommand request, CancellationToken cancellationToken)
        {
            var userId = userContext.GetCurrentUser()?.Id;
            var airline = mapper.Map<Domain.Entities.Airline>(request);
            airline.AdminId = userId;
            int id = await airlineRepository.Add(airline);
            return id;
        }
    }
}
