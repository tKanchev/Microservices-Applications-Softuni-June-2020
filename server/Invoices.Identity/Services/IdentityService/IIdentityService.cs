using Invoices.Identity.Database.Entities;
using Invoices.Identity.Models.OutputModels;
using System;
using System.Threading.Tasks;

namespace Invoices.Identity.Services.IdentityService
{
    public interface IIdentityService
    {
        AuthenticatedUserModel Authenticate(User user);

        Task ChangePassword(Guid userId, string password);
    }
}
