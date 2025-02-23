using Airline.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.User.Commands
{
    public class RegisterUserCommandHandler(IAccountRepository accountRepository,IMapper mapper) : IRequestHandler<RegisterUserCommand, IEnumerable<IdentityError>>
    {
        public async Task<IEnumerable<IdentityError>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<Domain.Entities.User>(request);
            var errors = await accountRepository.RegisterUser(user, request.Password);
            return errors;
        }
    }
}
