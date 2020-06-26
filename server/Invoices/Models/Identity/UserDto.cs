﻿using System;

namespace Invoices.Models.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string NationalIdentityNumber { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
