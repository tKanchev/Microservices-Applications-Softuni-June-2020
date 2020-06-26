using System;

namespace Invoices.Identity.Models
{
    public class AuthenticatedUser
    {
        public Guid UserId { get; }

        public string Token { get; }

        public AuthenticatedUser(Guid userId, string token)
        {
            this.UserId = userId;
            this.Token = token;
        }
    }
}
