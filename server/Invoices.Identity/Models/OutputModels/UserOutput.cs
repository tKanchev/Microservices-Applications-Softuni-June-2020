using System;

namespace Invoices.Identity.Models.OutputModels
{
    public class UserOutput
    {
        public Guid Id { get; set; }

        public string NationalIdentityNumber { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
