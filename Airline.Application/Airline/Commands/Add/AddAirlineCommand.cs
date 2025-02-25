using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Airline.Commands.Add
{
    public class AddAirlineCommand : IRequest<int>
    {
        [Required]
        public string Name { get; set; } = default!;
        [Required]
        [Length(10, 10, ErrorMessage = "Must be of length 10")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Must be made of numbers only")]
        public string? ContactNumber { get; set; }
        [Required]

        public string ManagerID { get; set; } = default!;
    }
}
