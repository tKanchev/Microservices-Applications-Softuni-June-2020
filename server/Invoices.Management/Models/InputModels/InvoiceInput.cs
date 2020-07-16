using System.ComponentModel.DataAnnotations;

namespace Invoices.Management.Models.InputModels
{
    public class InvoiceInput
    {
        [Required]
        public string IdNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]

        public decimal Amount { get; set; }
    }
}
