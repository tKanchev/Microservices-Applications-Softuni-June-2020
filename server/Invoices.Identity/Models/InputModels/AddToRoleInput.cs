using System;
using System.ComponentModel.DataAnnotations;

namespace Invoices.Identity.Models.InputModels
{
    public class AddToRoleInput
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]

        public Guid RoleId { get; set; }
    }
}
