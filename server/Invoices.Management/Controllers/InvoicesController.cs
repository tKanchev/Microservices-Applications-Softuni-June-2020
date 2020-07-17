using Invoices.Management.HttpServices;
using Invoices.Management.Models.InputModels;
using Invoices.Management.Services.InvoiceService;
using Invoices.Shared.Controllers;
using Invoices.Shared.Models.MessageModels;
using Invoices.Shared.Services.CurrentUserService;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Invoices.Management.Controllers
{
    public class InvoicesController : ApiController
    {
        private readonly IInvoiceService invoiceService;
        private readonly ILoggedUserService loggedUserService;
        private readonly IBus publisher;
        private readonly IHttpUserService userService;

        public InvoicesController(IInvoiceService invoiceService, ILoggedUserService loggedUserService, IBus publisher, IHttpUserService userService)
        {
            this.invoiceService = invoiceService;
            this.loggedUserService = loggedUserService;
            this.publisher = publisher;
            this.userService = userService;
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
        [Authorize(Roles = "Admin")]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create(InvoiceInput input)
        {
            var userId = await this.userService.GetUserIdByIdNumber(input.IdNumber);

            await this.invoiceService.CreateAsync(input, userId);

            await publisher.Publish(new CreatedInvoiceMessage
            {
                UserId = userId,
                Amount = input.Amount
            });

            return Ok("Invoice is generated");
        }
    }
}
