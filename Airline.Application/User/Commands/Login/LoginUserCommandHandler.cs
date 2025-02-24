using Airline.Domain.Entities;
using Airline.Domain.Entities.AuthEntities;
using Airline.Domain.Exceptions;
using Airline.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.User.Commands.Login
{
    public class LoginUserCommandHandler(ILogger<LoginUserCommandHandler> logger,
        ITokenRepository tokenRepository,
        UserManager<Domain.Entities.User> userManager) : IRequestHandler<LoginUserCommand, AuthResponse?>
    {
        public async Task<AuthResponse?> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("looking for user with email: {Email}", request.Email);

            var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new NotFoundException("User Does not Exist");
            }

            bool isValidCredentials = await userManager.CheckPasswordAsync(user, request.Password);
            if (isValidCredentials)
            {
                var token = await tokenRepository.GenerateToken(user.Id);
                return token;
            }

            return null;
        }
    }
}
