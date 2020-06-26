using Invoices.Data;
using Invoices.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Invoices.Services.Indentity.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly InvoicesDbContext db;

        public RoleService(InvoicesDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string roleName)
        {
            var role = new Role
            {
                Name = roleName
            };

            await this.db.Roles.AddAsync(role);
            await this.db.SaveChangesAsync();
        }

        public async Task<Role> GetByNameAsync(string roleName)
            => await this.db.Roles
                .SingleOrDefaultAsync(r => r.Name == roleName);

        public async Task<Role> GetByIdAsync(Guid id)
            => await this.db.Roles
                .SingleOrDefaultAsync(r => r.Id == id);

        public async Task<bool> ExistsByNameAsync(string roleName)
            => await this.db.Roles
                  .AnyAsync(r => r.Name.ToLower() == roleName.ToLower());

        public async Task<bool> ExistsByIdAsync(Guid id)
            => await this.db.Roles
                  .AnyAsync(r => r.Id == id);

        public async Task AddToRoleAsync(Guid userId, Guid roleId)
        {
            await this.db.AddAsync(new RoleUser 
            { 
                UserId = userId, RoleId = roleId 
            });

            await this.db.SaveChangesAsync();
        }
    }
}
