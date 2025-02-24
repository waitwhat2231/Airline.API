using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Airline.Application.User.Commands
{
    public class RegisterUserCommand : IRequest<IEnumerable<IdentityError>>
    {
        public string UserName { get; set; } = default!;
        [EmailAddress]
        public string Email { get; set; } = default!;
        [RegularExpression("^[0-9]*$", ErrorMessage = "Must be made of numbers")]
        public string PassportNumber { get; set; }
        [PasswordPropertyText]
        public string Password { get; set; } = default!;
    }
}
