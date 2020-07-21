using Invoices.Logger.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Invoices.Logger.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogsController : ControllerBase
    {
        private readonly ILoggerService loggerService;

        public LogsController(ILoggerService loggerService)
        {
            this.loggerService = loggerService;
        }

        [Authorize]
        [HttpGet]
        [Route(nameof(All))]
        public async Task<IActionResult> All()
        {
            return Ok(await this.loggerService.AllAsync());
        }
    }
}
