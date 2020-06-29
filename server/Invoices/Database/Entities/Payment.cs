using System;

namespace Invoices.Database.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }

        public decimal Amount { get; set; }

        public Guid InvoiceId { get; set; }

        public Invoice Invoice { get; set; }

        public Guid UserId { get; set; }
    }
}
