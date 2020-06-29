using Invoices.Identity.Database;
using Invoices.Identity.Database.Entities;
using Invoices.Identity.Models.OutputModels;
using Invoices.Identity.Services.PasswordService;
using Invoices.Identity.Services.TokenService;
using Invoices.Identity.Services.UserService;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Invoices.Identity.Services.IdentityService
{
    public class IdentityService : IIdentityService
    {
        private readonly ITokenService tokenService;
        private readonly IUserService userService;
        private readonly IPasswordService passwordService;
        private readonly InvoicesIdentityDbContext db;

        public IdentityService(
            ITokenService tokenService,
            IUserService userService,
            IPasswordService passwordService,
            InvoicesIdentityDbContext db)
        {
            this.tokenService = tokenService;
            this.userService = userService;
            this.passwordService = passwordService;
            this.db = db;
        }

        public AuthenticatedUserModel Authenticate(User user)
        {
            var token = this.tokenService.Generate(user);

            return new AuthenticatedUserModel(user.Id, token);
        }

        public async Task ChangePassword(Guid userId, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new NullReferenceException("Password is required");
            }

            var user = await this.userService.GetByIdAsync(userId);
            if (user == null)
            {
                throw new InvalidDataException("User not exists");
            }

            var newPassword = this.passwordService.GenerateHashAndSalt(password);

            user.PasswordHash = newPassword.Hash;
            user.PasswordSalt = newPassword.Salt;

            await this.db.SaveChangesAsync();
        }
    }
}
