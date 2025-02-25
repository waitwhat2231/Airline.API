using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Runtime.InteropServices;

namespace Airline.Application.User.Commands.Register
{
    public class RegisterUserCommand : IRequest<IEnumerable<IdentityError>>
    {
        [Required]
        public string UserName { get; set; } = default!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = default!;
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Must be made of numbers")]
        public string PassportNumber { get; set; } = default!;
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; } = default!;
        
        
    }
}
