using Invoices.Data.Entities;
using Invoices.Identity.Models;
using Invoices.Services.Indentity.TokenService;
using System.Threading.Tasks;

namespace Invoices.Services.Indentity.IdentityService
{
    public class IdentityService : IIdentityService
    {
        private readonly ITokenService tokenService;

        public IdentityService(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        public AuthenticatedUser Authenticate(User user)
        {
            var token = this.tokenService.GenerateToken(user);

            return new AuthenticatedUser(user.Id, token);
        }

        public Task ChangePassword(ChangePasswordInput changePasswordInput)
        {
            throw new System.NotImplementedException();
        }
    }
}
