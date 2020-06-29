using System;
using System.Collections.Generic;

namespace Invoices.Identity.Database.Entities
{
    public class Role
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<RoleUser> RoleUsers { get; set; } = new List<RoleUser>();
    }
}
