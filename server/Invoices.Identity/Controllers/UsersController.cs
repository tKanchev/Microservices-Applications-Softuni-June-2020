using Invoices.Identity.Models.InputModels;
using Invoices.Identity.Services.IdentityService;
using Invoices.Identity.Services.UserService;
using Invoices.Shared.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Invoices.Identity.Controllers
{
    public class UsersController : ApiController
    {
        private const string UserNotExistsErrorMessage = "User not exists.";
        private const string EmptyPasswordErrorMessage = "Password cannot be empty.";

        private readonly IUserService userService;
        private readonly IIdentityService identityService;

        public UsersController(IUserService userService, IIdentityService identityService)
        {
            this.userService = userService;
            this.identityService = identityService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route(nameof(All))]
        public async Task<IActionResult> All()
        {
            var users = await this.userService.AllAsync();

            return Ok(users);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route(nameof(Delete))]
        public async Task<IActionResult> Delete([FromBody] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Id can not be null.");
            }

            await this.userService.DeleteById(id);

            return Ok("User deleted.");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route(nameof(ChangePassword))]
        public async Task<IActionResult> ChangePassword(ChangePasswordInput input)
        {
            if (string.IsNullOrEmpty(input.Password))
            {
                return BadRequest(EmptyPasswordErrorMessage);
            }

            var userExists = await this.userService.ExistsByIdAsync(input.UserId);
            if (!userExists)
            {
                return BadRequest(UserNotExistsErrorMessage);
            }

            await this.identityService.ChangePassword(input.UserId, input.Password);

            return Ok("Password changed!");
        }
    }
}
