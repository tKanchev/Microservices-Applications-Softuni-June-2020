using System.ComponentModel.DataAnnotations;

namespace Invoices.Identity.Models.InputModels
{
    public class CreateUserInput
    {
        [Required]
        public string NationalIdentityNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
