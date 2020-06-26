﻿using System;
using System.Collections.Generic;

namespace Invoices.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string NationalIdentityNumber { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public List<RoleUser> RoleUsers { get; set; } = new List<RoleUser>();

        public List<Invoice> Invoices { get; set; } = new List<Invoice>();

        public List<Payment> Payments { get; set; } = new List<Payment>();
    }
}
