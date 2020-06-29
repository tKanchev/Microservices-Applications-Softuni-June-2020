using System;

namespace Invoices.Database.Entities
{
    public class Invoice
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
