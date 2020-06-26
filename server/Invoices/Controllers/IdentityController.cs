using Invoices.Identity.Models;
using Invoices.Services.Indentity.IdentityService;
using Invoices.Services.Indentity.PasswordService;
using Invoices.Services.Indentity.UserService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Invoices.Controllers
{
    public class IdentityController : ApiController
    {
        private const string UserNotExistErrorMessage = "User not exists.";
        private const string InvalidCredentialsErrorMessage = "Invalid credentials.";

        private readonly IUserService userService;
        private readonly IPasswordService passwordService;
        private readonly IIdentityService identityService;

        public IdentityController(IUserService userService, IPasswordService passwordService, IIdentityService identityService)
        {
            this.userService = userService;
            this.passwordService = passwordService;
            this.identityService = identityService;
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

            await this.userService.CreateAsync(input.NationalIdentityNumber, input.Name, input.Email, input.Password);

            return Ok("User created succsessfully");
        }
    }
}
