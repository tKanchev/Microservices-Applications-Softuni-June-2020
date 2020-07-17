using Invoices.Notifications.Hubs;
using Invoices.Shared.Models.MessageModels;
using MassTransit;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Invoices.Notifications.MessageConsumers
{
    public class CreatedInvoiceMessageConsumer : IConsumer<CreatedInvoiceMessage>
    {
        private readonly IHubContext<NotificationsHub> hub;

        public CreatedInvoiceMessageConsumer(IHubContext<NotificationsHub> hub)
        {
            this.hub = hub;
        }

        public async Task Consume(ConsumeContext<CreatedInvoiceMessage> context)
        {
            await this.hub.Clients.User(context.Message.UserId.ToString()).SendAsync("ReceiveNotification", context.Message);
        }
    }
}
