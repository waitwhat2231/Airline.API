using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Airline.Commands
{
    public class AddAirlineCommand : IRequest<int>
    {
        public String Name { get; set; }
        [Required]
        [Length(10,10,ErrorMessage ="Must be of length 10")]
        [RegularExpression("^[0-9]*$",ErrorMessage ="Must be made of numbers only")]
        public String ContactNumber { get; set; }
    }
}
