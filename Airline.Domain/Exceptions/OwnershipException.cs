using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Domain.Exceptions
{
    public class OwnershipException(string message) : Exception(message)
    {
    }
}
