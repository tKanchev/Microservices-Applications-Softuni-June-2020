using Invoices.Management.Database;
using Invoices.Management.Database.Entities;
using Invoices.Management.Models.InputModels;
using Invoices.Management.Models.OutputModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Invoices.Management.Services.InvoiceService
{
    public class InvoiceService : IInvoiceService
    {
        private readonly InvoicesManagementDbContext db;

        public InvoiceService(InvoicesManagementDbContext db)
        {
            this.db = db;
        }

        public async Task<InvoiceOutput[]> AllAsync()
            => await this.db.Invoices
                .Select(i => new InvoiceOutput
                {
                    Id = i.Id,
                    Number = i.Number,
                    Date = i.Date,
                    Amount = i.Amount,
                    NationalIdentityNumber = i.Client.NationalIdentityNumber,
                    ClientName = i.Client.ClientName
                })
                .ToArrayAsync();

        public async Task<InvoiceOutput[]> AllByUserIdAsync(Guid userId)
            => await this.db.Invoices
                    .Where(i => i.Client.UserId == userId)
                    .Select(i => new InvoiceOutput
                    {
                        Id = i.Id,
                        Number = i.Number,
                        Date = i.Date,
                        Amount = i.Amount,
                        NationalIdentityNumber = i.Client.NationalIdentityNumber,
                        ClientName = i.Client.ClientName
                    })
                    .ToArrayAsync();

        public async Task CreateAsync(InvoiceInput input, Guid userId)
        {
            var client = await this.db.Clients.FirstOrDefaultAsync(c => c.ClientName == input.Name);
            if (client == null)
            {
                client = new Client
                {
                    UserId = userId,
                    ClientName = input.Name,
                    NationalIdentityNumber = input.IdNumber
                };
            }
            var invoice = new Invoice
            {
                Date = DateTime.Now,
                Amount = input.Amount,
                Client = client
            };

            await this.db.AddAsync(invoice);
            await this.db.SaveChangesAsync();
        }

    }
}
