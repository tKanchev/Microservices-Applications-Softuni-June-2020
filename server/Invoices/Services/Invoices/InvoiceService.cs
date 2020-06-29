using Invoices.Database;
using Invoices.Database.Entities;
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
                .Select(i => new InvoiceDto 
                {
                    Id = i.Id,
                    Number = i.Number,
                    UserId = i.UserId,
                    Date = i.Date,
                    Amount = i.Amount,
                    NationalIdentityNumber = i.NationalIdentityNumber
                })
                .ToArrayAsync();

        public async Task<InvoiceDto[]> AllByUserIdAsync(Guid id)
           => await this.db.Invoices
                .Where(i => i.UserId == id)
               .Select(i => new InvoiceDto
               {
                   Id = i.Id,
                   Number = i.Number,
                   UserId = i.UserId,
                   ClientName = i.ClientName,
                   Date = i.Date,
                   Amount = i.Amount,
                   NationalIdentityNumber = i.NationalIdentityNumber
               })
               .ToArrayAsync();

        public async Task CreateAsync(InvoiceInput input)
        {
            var invoice = new Invoice
            {
                UserId = input.UserId,
                Date = DateTime.Now,
                Amount = input.Amount,
                //NationalIdentityNumber = user.NationalIdentityNumber //TODO Get National Id Number
            };

            await this.db.AddAsync(invoice);
            await this.db.SaveChangesAsync();
        }
    }
}
