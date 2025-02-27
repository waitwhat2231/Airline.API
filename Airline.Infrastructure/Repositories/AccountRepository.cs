using Airline.Domain.Entities;
using Airline.Domain.Exceptions;
using Airline.Domain.Repositories;
using Airline.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Infrastructure.Repositories
{
    public class AccountRepository(UserManager<User> userManager,
          AirlineDbContext dbcontext
          ) : IAccountRepository
    {
        public async Task<User> GetUserAsync(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                throw new NotFoundException("Not Found");
            }
            return user;
        }
        public async Task<bool> FillWallet(string email, int amount)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return false;
            }
            user.Wallet += amount;
            await userManager.UpdateAsync(user);
            await dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<string> Register(User user, string password, string role)
        {
            var res = await userManager.CreateAsync(user, password);
            if (res.Succeeded)
            {
                await userManager.AddToRoleAsync(user, role);
                return user.Id;
            }
            return "Error when adding User";
        }

        public async Task<IEnumerable<IdentityError>> RegisterAdmin(User user, string password)
        {
            var check = await userManager.CreateAsync(user, password);
            if (check.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Administrator");
            }
            return check.Errors;
        }

        public async Task<IEnumerable<IdentityError>> RegisterUser(User user, string password)
        {
            var check = await userManager.CreateAsync(user, password);

            if (check.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "User");
                user.Wallet = 0;
                await dbcontext.SaveChangesAsync();
            }
            return check.Errors;
        }
        private async Task<User> getFromPassportNum(string passportNum) {
            var user = await dbcontext.Users.FirstOrDefaultAsync(u => u.PassportNumber == passportNum);
            return user;
        }
        public async Task<int> NumberOfUsersInRole(string roleId)
        {
            var num = await dbcontext.UserRoles.Where(ur => ur.RoleId == roleId).CountAsync();
            return num;
        }
        public async Task<bool> CheckPassword(string userId, string password)
        {
            var user = await GetUserAsync(userId);
            if (user == null || password == null)
            {
                return false;
            }
            var sucess = await userManager.CheckPasswordAsync(user, password);
            return sucess;
        }

        public async Task UpdateUser(User user)
        {
            await userManager.UpdateAsync(user);
            await dbcontext.SaveChangesAsync();
        }

        public async Task<bool> UserExists(string email, string passportNumber)
        {
            var userInSystem = await userManager.FindByEmailAsync(email);
            if (userInSystem != null)
            {
                return true;
            }
            userInSystem = await getFromPassportNum(passportNumber);
            if (userInSystem != null)
            {
                return true;
            }
            return false;
        }
    }
    }
