using System;

namespace Invoices.Data.Entities
{
    public class RoleUser
    {
        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
