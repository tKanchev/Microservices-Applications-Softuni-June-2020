using Invoices.Data;
using Invoices.Data.Entities;
using Invoices.Models.DTOs;
using Invoices.Services.Indentity.PasswordService;
using Invoices.Services.Indentity.RoleService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Invoices.Services.Indentity.UserService
{
    public class UserService : IUserService
    {
        private readonly InvoicesDbContext db;
        private readonly IPasswordService passwordService;
        private readonly IRoleService roleService;

        public UserService(InvoicesDbContext db, IPasswordService passwordService, IRoleService roleService)
        {
            this.db = db;
            this.passwordService = passwordService;
            this.roleService = roleService;
        }

        public async Task CreateAsync(string nationalIdentityNumber, string name, string email, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new NullReferenceException("Password is required");
            }

            var passwordObject = this.passwordService.CreateHashAndSalt(password);

            var user = new User
            {
                NationalIdentityNumber = nationalIdentityNumber,
                Name = name,
                Email = email,
                PasswordHash = passwordObject.Hash,
                PasswordSalt = passwordObject.Salt
            };

            await this.db.Users.AddAsync(user);
            await this.db.SaveChangesAsync();
        }

        public async Task<bool> ExistsByIdAsync(Guid id)
            => await this.db.Users
                .AnyAsync(u => u.Id == id);

        public async Task<bool> ExistsByEmailAsync(string email)
            => await this.db.Users
                .AnyAsync(u => u.Email.ToLower() == email.ToLower());

        public async Task<User> GetByEmailAsync(string email)
            => await this.db.Users
                .Include(u => u.RoleUsers)
                .ThenInclude(ru => ru.Role)
                .SingleOrDefaultAsync(u => u.Email == email);

        public async Task<User> GetByIdAsync(Guid id)
            => await this.db.Users
                .Include(u => u.RoleUsers)
                .ThenInclude(ru => ru.Role)
                .SingleOrDefaultAsync(u => u.Id == id);

        public async Task<bool> IsInRoleAsync(string userEmail, string roleName)
        {
            var role = await this.roleService.GetByNameAsync(roleName);
            if (role == null)
            {
                return false;
            }

            var user = await GetByEmailAsync(userEmail);
            if (user == null)
            {
                throw new Exception("User not exists!");
            }

            return await this.db.RoleUsers.AnyAsync(ru => ru.RoleId == role.Id && ru.UserId == user.Id);
        }

        public async Task AddToRoleAsync(Guid userId, Guid roleId)
        {
            var roleUserRelation = new RoleUser
            {
                RoleId = roleId,
                UserId = userId,
            };

            await this.db.RoleUsers.AddAsync(roleUserRelation);
            await this.db.SaveChangesAsync();
        }

        public async Task<UserDto[]> AllAsync()
            => await this.db.Users
                .Select(x => new UserDto 
                {
                    Id = x.Id,
                    Email = x.Email,
                    Name = x.Name,
                    NationalIdentityNumber = x.NationalIdentityNumber
                })
                .ToArrayAsync();
    }
}
