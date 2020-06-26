using Invoices.Models.Invoices;
using System.Threading.Tasks;

namespace Invoices.Services.Invoices
{
    public interface IInvoiceService
    {
        Task<InvoiceDto[]> AllAsync();

        Task<InvoiceClientDto[]> AllClientsAsync();

        Task CreateAsync(InvoiceInput input);
    }
}
