using Invoices.Management.Models.InputModels;
using Invoices.Management.Models.OutputModels;
using System;
using System.Threading.Tasks;

namespace Invoices.Management.Services.InvoiceService
{
    public interface IInvoiceService
    {
        Task<InvoiceOutput[]> AllAsync();

        Task<InvoiceOutput[]> AllByUserIdAsync(Guid userId);

        Task CreateAsync(InvoiceInput input, Guid userId);
    }
}
