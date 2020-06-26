using System.ComponentModel.DataAnnotations;

namespace Invoices.Models.Identity
{
    public class RoleInput
    {
        [Required]
        public string Name { get; set; }
    }
}
