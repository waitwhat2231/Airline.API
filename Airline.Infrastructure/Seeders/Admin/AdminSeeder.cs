using Airline.Domain.Entities;
using Airline.Domain.Repositories;
using Airline.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Infrastructure.Seeders.Admin
{
    public class AdminSeeder(AirlineDbContext context,
        UserManager<User> userManager
        , IAccountRepository repository) : IAdminSeeder
    {
        public async Task Seed()
        {
            if (await context.Database.CanConnectAsync())
            {
                if (!context.Users.Any())
                {
                    User admin = GetAdmin();
                    await repository.Register(admin, "P@ssword1", "Administrator");
                }
            }
        }
        private static User GetAdmin()
        {
            User user = new()
            {
                UserName = "Admin1",
                Email = "Admin1@gmail.com",
                PassportNumber = "1234567890"
            };
            return user;
        }
    }
}
