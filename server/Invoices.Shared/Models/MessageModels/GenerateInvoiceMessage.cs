using System;

namespace Invoices.Shared.Models.MessageModels
{
    public class GenerateInvoiceMessage
    {
        public Guid UserId { get; set; }

        public string IdNumber { get; set; }

        public string Name { get; set; }

        public decimal Amount { get; set; }
    }
}
