using Invoices.Data.Entities;
using Invoices.Identity.Models;
using System.Threading.Tasks;

namespace Invoices.Services.Indentity.IdentityService
{
    public interface IIdentityService
    {
        AuthenticatedUser Authenticate(User user);

        Task ChangePassword(ChangePasswordInput changePasswordInput);
    }
}
