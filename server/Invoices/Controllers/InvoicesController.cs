using Invoices.Models.Invoices;
using Invoices.Services.Indentity.UserService;
using Invoices.Services.Invoices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Invoices.Controllers
{
    
    public class InvoicesController : ApiController
    {
        private readonly IUserService userService;
        private readonly IInvoiceService invoiceService;

        public InvoicesController(IUserService userService, IInvoiceService invoiceService)
        {
            this.userService = userService;
            this.invoiceService = invoiceService;
        }

        [Authorize]
        [HttpGet]
        [Route(nameof(All))]
        public async Task<IActionResult> All()
            => Ok(await this.invoiceService.AllAsync());

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create(InvoiceInput input)
        {
            await this.invoiceService.CreateAsync(input);

            return Ok("Invoice created successfully");
        }

        [Authorize]
        [HttpGet]
        [Route(nameof(AllClients))]
        public async Task<IActionResult> AllClients()
            => Ok(await this.invoiceService.AllClientsAsync());
    }
}
