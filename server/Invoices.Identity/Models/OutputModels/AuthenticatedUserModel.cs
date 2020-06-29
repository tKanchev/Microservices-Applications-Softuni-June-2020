using System;

namespace Invoices.Identity.Models.OutputModels
{
    public class AuthenticatedUserModel
    {
        public Guid UserId { get; }

        public string Token { get; }

        public AuthenticatedUserModel(Guid userId, string token)
        {
            this.UserId = userId;
            this.Token = token;
        }
    }
}
