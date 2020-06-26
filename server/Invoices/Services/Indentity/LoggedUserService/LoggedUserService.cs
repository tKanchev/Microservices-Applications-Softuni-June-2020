using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace Invoices.Services.Indentity.LoggedUserService
{
    public class LoggedUserService : ILoggedUserService
    {
        public string UserId { get; }

        public LoggedUserService(IHttpContextAccessor httpContextAccessor)
        {
            var user = httpContextAccessor.HttpContext?.User;

            if (user == null)
            {
                throw new InvalidOperationException("This request does not have an authenticated user.");
            }

            UserId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
