using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Domain.Exceptions
{
    public class UserAlreadyExistsException(string email) : Exception($"User with email {email} already exists")
    {
    }
}
