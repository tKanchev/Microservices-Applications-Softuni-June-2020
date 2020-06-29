using Invoices.Models.Invoices;
using Invoices.Services.Invoices;
using Invoices.Shared.Controllers;
using Invoices.Shared.Services.CurrentUserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

using static Invoices.Shared.Constants.IdentityConstants.Admin;

namespace Invoices.Controllers
{

    public class InvoicesController : ApiController
    {
        private readonly IInvoiceService invoiceService;
        private readonly ILoggedUserService loggedUserService;

        public InvoicesController(IInvoiceService invoiceService, ILoggedUserService loggedUserService)
        {
            this.invoiceService = invoiceService;
            this.loggedUserService = loggedUserService;
        }

        [Authorize]
        [HttpGet]
        [Route(nameof(All))]
        public async Task<IActionResult> All()
        {
            if (this.loggedUserService.IsAdmin)
            {
                return Ok(await this.invoiceService.AllAsync());
            }

            return Ok(await this.invoiceService.AllByUserIdAsync(Guid.Parse(this.loggedUserService.UserId)));
        }

        [HttpPost]
        [Authorize(Roles = AdminRoleName)]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create(InvoiceInput input)
        {
            await this.invoiceService.CreateAsync(input);

            return Ok("Invoice created successfully");
        }

        //[Authorize]
        //[HttpGet]
        //[Route(nameof(AllClients))]
        //public async Task<IActionResult> AllClients()
        //    => Ok(await this.invoiceService.AllClientsAsync());
    }
}
