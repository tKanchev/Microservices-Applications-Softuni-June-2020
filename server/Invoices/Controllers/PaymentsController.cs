using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Invoices.Controllers
{
    public class PaymentsController : ApiController
    {
        [Authorize]
        [HttpGet]
        [Route(nameof(All))]
        public async Task<IActionResult> All()
        {
            return Ok("plashtaniqta bokluk");
        }
    }
}
