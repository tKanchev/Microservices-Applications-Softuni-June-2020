using Invoices.Identity.Database;
using Invoices.Identity.Extensions;
using Invoices.Identity.Services.IdentityService;
using Invoices.Identity.Services.PasswordService;
using Invoices.Identity.Services.RoleService;
using Invoices.Identity.Services.TokenService;
using Invoices.Identity.Services.UserService;
using Invoices.Shared.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Invoices.Identity
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
                .AddWebService<InvoicesIdentityDbContext>(this.Configuration)
                .AddTransient<IRoleService, RoleService>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<IPasswordService, PasswordService>()
                .AddTransient<IIdentityService, IdentityService>()
                .AddTransient<ITokenService, TokenService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app.UseWebService(env)
                .UseDatabaseMigration()
                .SeedAdminUserData();
    }
}
