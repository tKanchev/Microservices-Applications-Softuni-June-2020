using System;
using System.ComponentModel.DataAnnotations;

namespace Invoices.Models.Invoices
{
    public class InvoiceInput
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]

        public decimal Amount { get; set; }
    }
}
