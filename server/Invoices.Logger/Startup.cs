using Invoices.Logger.Database;
using Invoices.Logger.MessageConsumers;
using Invoices.Logger.Services;
using Invoices.Shared.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Invoices.Logger
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddWebService<InvoicesLoggerDbContext>(this.Configuration)
                .AddMessaging(typeof(LogMessageConsumer))
                .AddTransient<ILoggerService, LoggerService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app.UseWebService(env)
                    .UseDatabaseMigration();
    }
}
