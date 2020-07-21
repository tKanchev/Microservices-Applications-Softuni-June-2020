using Invoices.Identity.Models.InputModels;
using Invoices.Identity.Services.IdentityService;
using Invoices.Identity.Services.PasswordService;
using Invoices.Identity.Services.UserService;
using Invoices.Shared.Controllers;
using Invoices.Shared.Extensions;
using Invoices.Shared.Models.MessageModels;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Invoices.Identity.Controllers
{
    public class IdentityController : ApiController
    {
        private const string UserNotExistErrorMessage = "User not exists.";
        private const string InvalidCredentialsErrorMessage = "Invalid credentials.";

        private readonly IUserService userService;
        private readonly IPasswordService passwordService;
        private readonly IIdentityService identityService;
        private readonly IBus publisher;

        public IdentityController(
            IUserService userService,
            IPasswordService passwordService,
            IIdentityService identityService,
            IBus publisher)
        {
            this.userService = userService;
            this.passwordService = passwordService;
            this.identityService = identityService;
            this.publisher = publisher;
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult> Login(LoginInput input)
        {
            var user = await this.userService.GetByEmailAsync(input.Email);
            if (user == null)
            {
                return BadRequest(UserNotExistErrorMessage);
            }

            var passwordValid = this.passwordService.CheckPassword(user.PasswordHash, user.PasswordSalt, input.Password);
            if (!passwordValid)
            {
                return BadRequest(InvalidCredentialsErrorMessage);
            }

            var authenticatedUser = this.identityService.Authenticate(user);

            return Ok(authenticatedUser);
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(CreateUserInput input)
        {
            var user = await this.userService.GetByEmailAsync(input.Email);
            if (user != null)
            {
                return BadRequest("User already exists!");
            }

            var userId = Guid.NewGuid();

            await this.userService.CreateAsync(userId, input.NationalIdentityNumber, input.Name, input.Email, input.Password);
            
            await publisher.Publish(new AddClientMessage
            {
                UserId = userId,
                ClientName = input.Name,
                NationalIdentityNumber = input.NationalIdentityNumber
            });

            return Ok("User created succsessfully");
        }

        [HttpGet]
        [Authorize]
        [Route(nameof(IsAdmin))]
        public ActionResult IsAdmin()
        {
            return Ok(this.User.IsAdmin());
        }
    }
}
