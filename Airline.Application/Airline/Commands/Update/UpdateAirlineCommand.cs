using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Airline.Commands.Update
{
    public class UpdateAirlineCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        
        [Length(10, 10, ErrorMessage = "Must be of length 10")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Must be made of numbers only")]
        public string? ContactNumber { get; set; }
    }
}
