using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Domain.Entities.AuthEntities
{
    public class RefreshTokenRequest
    {
        public string? RefreshToken { get; set; }
        public string? user_id { get; set; }
    }
}
