using Invoices.Data;
using Invoices.Services.Indentity.RoleService;
using Invoices.Services.Indentity.UserService;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Invoices.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<InvoicesDbContext>().Database.Migrate();
            }
            return app;
        }

        public static IApplicationBuilder SeedAdminUserData(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var userService = serviceScope.ServiceProvider.GetService<IUserService>();
                var roleService = serviceScope.ServiceProvider.GetService<IRoleService>();

                Task.Run(async () =>
                {
                    var adminName = "Admin";
                    var adminUserEmail = "admin@invoices.com";
                    var adminUserPass = "admin";
                    var roleExists = await roleService.ExistsByNameAsync(adminName);
                    if (!roleExists)
                    {
                        await roleService.CreateAsync(adminName);
                    }

                    var adminUserExists = await userService.ExistsByEmailAsync(adminUserEmail);
                    if (!adminUserExists)
                    {
                        await userService.CreateAsync(adminName, adminName, adminUserEmail, adminUserPass);
                    }



                    var userIsAdmin = await userService.IsInRoleAsync(adminUserEmail, adminName);
                    if (!userIsAdmin)
                    {
                        var adminRole = await roleService.GetByNameAsync(adminName);
                        var adminUser = await userService.GetByEmailAsync(adminUserEmail);
                        
                        await userService.AddToRoleAsync(adminUser.Id, adminRole.Id);
                    }
                })
                .Wait();
            }

            return app;
        }
    }
}
