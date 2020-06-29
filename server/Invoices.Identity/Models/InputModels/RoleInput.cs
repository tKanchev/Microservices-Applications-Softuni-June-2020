using System.ComponentModel.DataAnnotations;

namespace Invoices.Identity.Models.InputModels
{
    public class RoleInput
    {
        [Required]
        public string Name { get; set; }
    }
}
