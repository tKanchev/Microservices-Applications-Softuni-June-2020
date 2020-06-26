using System.ComponentModel.DataAnnotations;

namespace Invoices.Identity.Models
{
    public class LoginInput
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
