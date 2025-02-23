using Airline.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Domain.Repositories
{
    public interface IAccountRepository
    {
        public Task<User> GetUserAsync(string id);
        public Task<IEnumerable<IdentityError>> RegisterUser(User user, string password);
        public Task<string> Register(User user, string password, string role);
        public Task<bool> FillWallet(string email, int amount);
        //public Task<IEnumerable<IdentityError>> Verify(string email, string verficationToken);
        public Task<bool> CheckPassword(string userId, string password);
    }
}
