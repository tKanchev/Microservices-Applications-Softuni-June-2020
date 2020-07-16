using System;

namespace Invoices.Management.Models.InputModels
{
    public class ClientInputModel
    {
        public Guid UserId { get; set; }

        public string ClientName { get; set; }

        public string NationalIdentityNumber { get; set; }
    }
}
