using Airline.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Infrastructure.Seeders.Roles
{
    public class RolesSeeder(AirlineDbContext context) : IRolesSeeder
    {
        public async Task Seed()
        {
            if (await context.Database.CanConnectAsync())
            {
                if (!context.Roles.Any())
                {
                    var roles = GetRoles();
                    context.Roles.AddRange(roles);
                    await context.SaveChangesAsync();
                }
            }
        }
        public IEnumerable<IdentityRole> GetRoles()
        {
            List<IdentityRole> roles = [
                new ()
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
                new ()
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new ()
                {
                    Name = "AirlineManager",
                    NormalizedName = "AIRLINEMANAGER"
                }
                ];
            return roles;
        }
    }
}
