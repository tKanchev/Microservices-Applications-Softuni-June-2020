using System;

namespace Invoices.Models.Invoices
{
    public class InvoiceDto
    {
        public Guid Id { get; set; }

        public int Number { get; set; }

        public Guid UserId { get; set; }

        public string ClientName { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        public string NationalIdentityNumber { get; set; }
    }
}
