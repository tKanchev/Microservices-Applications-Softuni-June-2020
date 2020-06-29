using Invoices.Identity.Models.InputModels;
using Invoices.Identity.Services.RoleService;
using Invoices.Identity.Services.UserService;
using Invoices.Shared.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Invoices.Identity.Controllers
{
    public class RolesController : ApiController
    {
        private const string RoleExistErrorMessage = "Role already exists.";
        private const string RoleNotExistErrorMessage = "Role not exists.";
        private const string UserNotExistErrorMessage = "User not exists.";
        private const string NullErrorMessage = "Role name can not be empty.";

        private readonly IRoleService roleService;
        private readonly IUserService userService;

        public RolesController(IRoleService roleService, IUserService userService)
        {
            this.roleService = roleService;
            this.userService = userService;
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create(RoleInput role)
        {
            if (string.IsNullOrEmpty(role.Name))
            {
                return BadRequest(NullErrorMessage);
            }

            var exists = await this.roleService.ExistsByNameAsync(role.Name);
            if (exists)
            {
                return BadRequest(RoleExistErrorMessage);
            }

            await this.roleService.CreateAsync(role.Name);

            return Ok("Role created successfully");
        }

        [HttpPost]
        [Route(nameof(AddToRole))]
        public async Task<IActionResult> AddToRole(AddToRoleInput input)
        {
            var roleExists = await this.roleService.ExistsByIdAsync(input.RoleId);
            if (!roleExists)
            {
                return BadRequest(RoleNotExistErrorMessage);
            }

            var userExists = await this.userService.ExistsByIdAsync(input.UserId);
            if (!userExists)
            {
                return BadRequest(UserNotExistErrorMessage);
            }

            await this.roleService.AddToRoleAsync(input.UserId, input.RoleId);

            return Ok("User added successfully to role.");
        }
    }
}
