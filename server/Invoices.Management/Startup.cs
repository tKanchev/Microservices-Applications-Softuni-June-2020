using Invoices.Management.Database;
using Invoices.Management.HttpServices;
using Invoices.Management.HttpServices.Config;
using Invoices.Management.MessageConsumers;
using Invoices.Management.Services.ClientService;
using Invoices.Management.Services.InvoiceService;
using Invoices.Shared.Extensions;
using Invoices.Shared.Middlewares;
using Invoices.Shared.Services.CurrentToken;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;


namespace Invoices.Management
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
                .AddWebService<InvoicesManagementDbContext>(this.Configuration)
                .AddMessaging(typeof(AddClientMessageConsumer))
                .AddScoped<ICurrentTokenService, CurrentTokenService>()
                .AddTransient<JwtHeaderAuthenticationMiddleware>()
                .AddTransient<IInvoiceService, InvoiceService>()
                .AddTransient<IClientService, ClientService>();

            var serviceEndpoints = this.Configuration
                .GetSection(nameof(ServiceEndpoints))
                .Get<ServiceEndpoints>(config => config.BindNonPublicProperties = true);

            services
                .AddRefitClient<IHttpUserService>()
                .WithConfiguration(serviceEndpoints.Users);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection()
                .UseRouting()
                .UseJwtHeaderAuthentication()
                .UseAuthorization()
                .UseCors(options => options
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod())
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
        
    }
}
