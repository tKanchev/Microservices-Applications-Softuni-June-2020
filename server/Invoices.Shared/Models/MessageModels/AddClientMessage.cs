using System;

namespace Invoices.Shared.Models.MessageModels
{
    public class AddClientMessage
    {
        public Guid UserId { get; set; }

        public string ClientName { get; set; }

        public string NationalIdentityNumber { get; set; }
    }
}
