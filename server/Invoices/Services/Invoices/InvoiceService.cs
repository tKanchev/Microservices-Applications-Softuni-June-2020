using Invoices.Data;
using Invoices.Data.Entities;
using Invoices.Models.Invoices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Invoices.Services.Invoices
{
    public class InvoiceService : IInvoiceService
    {
        private readonly InvoicesDbContext db;

        public InvoiceService(InvoicesDbContext db)
        {
            this.db = db;
        }

        public async Task<InvoiceDto[]> AllAsync()
            => await this.db.Invoices
                .Include(i => i.User)
                .Select(i => new InvoiceDto 
                {
                    Id = i.Id,
                    Number = i.Number,
                    UserId = i.UserId,
                    ClientName = i.User.Name,
                    Date = i.Date,
                    Amount = i.Amount,
                    NationalIdentityNumber = i.NationalIdentityNumber
                })
                .ToArrayAsync();

        public async Task<InvoiceClientDto[]> AllClientsAsync()
            => await this.db.Users
                    .Select(u => new InvoiceClientDto
                    { 
                        UserId = u.Id,
                        Name = u.Name
                    })
                    .ToArrayAsync();

        public async Task CreateAsync(InvoiceInput input)
        {
            var user = await this.db.Users.FindAsync(input.UserId);
            
            var invoice = new Invoice
            {
                UserId = input.UserId,
                Date = DateTime.Now,
                Amount = input.Amount,
                NationalIdentityNumber = user.NationalIdentityNumber
            };

            await this.db.AddAsync(invoice);
            await this.db.SaveChangesAsync();
        }
    }
}
