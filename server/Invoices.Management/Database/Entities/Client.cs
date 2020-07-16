using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoices.Management.Database.Entities
{
    public class Client
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string ClientName { get; set; }

        public string NationalIdentityNumber { get; set; }

        public IEnumerable<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}
