using Invoices.Services.Indentity.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Invoices.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route(nameof(All))]
        public async Task<IActionResult> All()
        {
            var users = await this.userService.AllAsync();

            return Ok(users);
        }
    }
}
