using Invoices.Management.Database;
using Invoices.Management.Database.Entities;
using Invoices.Management.Models.InputModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Invoices.Management.Services.ClientService
{
    public class ClientService : IClientService
    {
        private readonly InvoicesManagementDbContext db;

        public ClientService(InvoicesManagementDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(ClientInputModel input)
        {
            var clientExists = await this.db.Clients.AnyAsync(c => c.UserId == input.UserId);
            if (clientExists)
            {
                throw new InvalidOperationException("Client with this UserId is already registered!");
            }

            await this.db.AddAsync(new Client 
            {
                UserId = input.UserId,
                ClientName = input.ClientName,
                NationalIdentityNumber = input.NationalIdentityNumber
            });

            await this.db.SaveChangesAsync();
        }
    }
}
