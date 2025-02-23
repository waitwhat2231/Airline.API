using Airline.Domain.Entities.AuthEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Domain.Repositories
{
    public interface ITokenRepository
    {
        public Task<AuthResponse?> GenerateToken(string UserIdentifier);
        public Task<string> CreateRefreshToken();
        public Task<AuthResponse?> VerifyRefreshToken(RefreshTokenRequest request);


    }
}
