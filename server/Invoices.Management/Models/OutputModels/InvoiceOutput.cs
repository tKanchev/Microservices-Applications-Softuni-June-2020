using System;

namespace Invoices.Management.Models.OutputModels
{
    public class InvoiceOutput
    {
        public Guid Id { get; set; }

        public int Number { get; set; }

        public string ClientName { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        public string NationalIdentityNumber { get; set; }
    }
}
