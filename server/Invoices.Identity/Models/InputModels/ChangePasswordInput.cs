using System;
using System.ComponentModel.DataAnnotations;

namespace Invoices.Identity.Models.InputModels
{
    public class ChangePasswordInput
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
