using System;

namespace Invoices.Management.Database.Entities
{
    public class Invoice
    {
        public Guid Id { get; set; }

        public int Number { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        public Guid ClientId { get; set; }

        public Client Client { get; set; }
    }
}
