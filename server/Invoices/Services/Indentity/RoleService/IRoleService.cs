using Invoices.Data.Entities;
using System;
using System.Threading.Tasks;

namespace Invoices.Services.Indentity.RoleService
{
    public interface IRoleService
    {
        Task CreateAsync(string roleName);

        Task<Role> GetByNameAsync(string roleName);
        
        Task<Role> GetByIdAsync(Guid Id);

        Task<bool> ExistsByNameAsync(string roleName);
        
        Task<bool> ExistsByIdAsync(Guid id);

        Task AddToRoleAsync(Guid userId, Guid roleId);
    }
}
