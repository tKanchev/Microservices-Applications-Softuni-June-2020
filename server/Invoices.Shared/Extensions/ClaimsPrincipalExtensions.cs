using System.Security.Claims;
using static Invoices.Shared.Constants.IdentityConstants;

namespace Invoices.Shared.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static bool IsAdmin(this ClaimsPrincipal user)
            => user.IsInRole(Admin.AdminRoleName);
    }
}
