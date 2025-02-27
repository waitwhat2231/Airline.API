using Airline.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.User.Commands.Wallet
{
    internal class FillWalletCommandHandler(IAccountRepository accountRepository) : IRequestHandler<FillWalletCommand, bool>
    {
        public async Task<bool> Handle(FillWalletCommand request, CancellationToken cancellationToken)
        {
            var success = await accountRepository.FillWallet(request.UserEmail, request.Amount);
            return success;
        }
    }
}
