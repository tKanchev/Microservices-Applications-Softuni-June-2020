using Invoices.Management.Models.InputModels;
using System.Threading.Tasks;

namespace Invoices.Management.Services.ClientService
{
    public interface IClientService
    {
        Task CreateAsync(ClientInputModel input);
    }
}
