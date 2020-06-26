using System;

namespace Invoices.Data.Entities
{
    public class Invoice
    {
        public Guid Id { get; set; }

        public int Number { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        public string NationalIdentityNumber { get; set; }
    }
}
