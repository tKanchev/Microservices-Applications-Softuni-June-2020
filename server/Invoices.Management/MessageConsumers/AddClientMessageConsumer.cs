using Invoices.Management.Models.InputModels;
using Invoices.Management.Services.ClientService;
using Invoices.Shared.Models.MessageModels;
using MassTransit;
using System.Threading.Tasks;

namespace Invoices.Management.MessageConsumers
{
    public class AddClientMessageConsumer : IConsumer<AddClientMessage>
    {
        private readonly IClientService clientService;

        public AddClientMessageConsumer(IClientService clientService)
        {
            this.clientService = clientService;
        }
        public async Task Consume(ConsumeContext<AddClientMessage> context)
        {
            await this.clientService.CreateAsync(new ClientInputModel
            {
                UserId = context.Message.UserId,
                ClientName = context.Message.ClientName,
                NationalIdentityNumber = context.Message.NationalIdentityNumber
            });
        }
    }
}
