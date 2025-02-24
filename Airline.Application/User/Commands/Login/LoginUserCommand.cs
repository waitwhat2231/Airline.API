using Airline.Domain.Entities.AuthEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.User.Commands.Login
{
    public class LoginUserCommand : IRequest<AuthResponse?>
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
