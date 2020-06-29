using Invoices.Shared.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace Invoices.Shared.Services.CurrentUserService
{
    public class LoggedUserService : ILoggedUserService
    {
        private readonly ClaimsPrincipal user;

        public LoggedUserService(IHttpContextAccessor httpContextAccessor)
        {
            this.user = httpContextAccessor.HttpContext?.User;

            if (user == null)
            {
                throw new InvalidOperationException("This request does not have an authenticated user.");
            }

            this.UserId = this.user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string UserId { get; }

        public bool IsAdmin => this.user.IsAdmin();
    }
}
