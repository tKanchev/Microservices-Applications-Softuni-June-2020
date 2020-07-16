using Invoices.Logger.Services;
using Invoices.Shared.Models.MessageModels;
using MassTransit;
using System.Threading.Tasks;

namespace Invoices.Logger.MessageConsumers
{
    public class LogMessageConsumer : IConsumer<LogMessage>
    {
        private readonly ILoggerService loggerService;

        public LogMessageConsumer(ILoggerService loggerService)
        {
            this.loggerService = loggerService;
        }

        public async Task Consume(ConsumeContext<LogMessage> context)
        {
            await loggerService.LogAsync(context.Message);
        }
    }
}
