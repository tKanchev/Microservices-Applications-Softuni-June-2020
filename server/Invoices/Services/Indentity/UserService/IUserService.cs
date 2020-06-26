using Invoices.Data.Entities;
using Invoices.Models.DTOs;
using System;
using System.Threading.Tasks;

namespace Invoices.Services.Indentity.UserService
{
    public interface IUserService
    {
        Task CreateAsync(string nationalIdentityNumber, string name, string email, string password);

        Task<User> GetByEmailAsync(string email);

        Task<User> GetByIdAsync(Guid id);

        Task<bool> ExistsByEmailAsync(string email);

        Task<bool> ExistsByIdAsync(Guid id);

        Task<bool> IsInRoleAsync(string userEmail, string roleName);

        Task AddToRoleAsync(Guid userId, Guid roleId);

        Task<UserDto[]> AllAsync();
    }
}
