using Airline.Domain.Entities.AuthEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.User.Commands.Token
{
    public class RefreshTokenRequestCommand : IRequest<AuthResponse>
    {
        public string? RefreshToken { get; set; }
    }
}
