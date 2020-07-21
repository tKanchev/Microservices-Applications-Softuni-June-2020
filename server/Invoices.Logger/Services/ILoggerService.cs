using Invoices.Logger.Models.Output;
using Invoices.Shared.Models.MessageModels;
using System.Threading.Tasks;

namespace Invoices.Logger.Services
{
    public interface ILoggerService
    {
        Task LogAsync(LogMessage message);
        Task<LogOutput[]> AllAsync();
    }
}
