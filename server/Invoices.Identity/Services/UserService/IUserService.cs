using Invoices.Identity.Database.Entities;
using Invoices.Identity.Models.OutputModels;
using System;
using System.Threading.Tasks;

namespace Invoices.Identity.Services.UserService
{
    public interface IUserService
    {
        Task CreateAsync(Guid userId, string nationalIdentityNumber, string name, string email, string password);

        Task<User> GetByEmailAsync(string email);

        Task<User> GetByIdAsync(Guid id);

        Task<bool> ExistsByEmailAsync(string email);

        Task<bool> ExistsByIdAsync(Guid id);

        Task<Guid> GetUserIdByIdNumber(string idNumber);

        Task<bool> IsInRoleAsync(string userEmail, string roleName);

        Task AddToRoleAsync(Guid userId, Guid roleId);

        Task<UserOutput[]> AllAsync();

        Task DeleteById(Guid id);
    }
}
