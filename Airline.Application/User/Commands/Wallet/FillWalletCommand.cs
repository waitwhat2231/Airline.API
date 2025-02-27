using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.User.Commands.Wallet
{
    public class FillWalletCommand : IRequest<bool>
    {
        [Required]
        public string? UserEmail { get; set; }
        [Required]
        [Range(0.0,1e9)]
        public int Amount { get; set; } = 0;
    }
}
