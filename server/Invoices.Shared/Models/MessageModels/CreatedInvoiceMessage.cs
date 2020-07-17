using System;

namespace Invoices.Shared.Models.MessageModels
{
    public class CreatedInvoiceMessage
    {
        public Guid UserId { get; set; }

        public decimal Amount { get; set; }

    }
}
