using Airline.Domain.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.User.Commands.Register.AirlineManager
{
    public class RegisterAirlineManagerCommandHandler(IAccountRepository repository, IMapper mapper) : IRequestHandler<RegisterAirlineManagerCommand, string>
    {
        public async Task<string> Handle(RegisterAirlineManagerCommand request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<Domain.Entities.User>(request);

            var userId = await repository.Register(user, request.Password, "AirlineManager");
            return userId;
        }
    }
}
