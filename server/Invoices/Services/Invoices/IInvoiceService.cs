using Invoices.Models.Invoices;
using System;
using System.Threading.Tasks;

namespace Invoices.Services.Invoices
{
    public interface IInvoiceService
    {
        Task<InvoiceDto[]> AllAsync();

        Task<InvoiceDto[]> AllByUserIdAsync(Guid id);

        Task CreateAsync(InvoiceInput input);
    }
}
