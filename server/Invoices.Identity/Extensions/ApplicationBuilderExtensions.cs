using Invoices.Identity.Services.RoleService;
using Invoices.Identity.Services.UserService;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

using static Invoices.Shared.Constants.IdentityConstants.Admin;

namespace Invoices.Identity.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedAdminUserData(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var userService = serviceScope.ServiceProvider.GetService<IUserService>();
            var roleService = serviceScope.ServiceProvider.GetService<IRoleService>();

            Task.Run(async () =>
            {
                var roleExists = await roleService.ExistsByNameAsync(AdminRoleName);
                if (!roleExists)
                {
                    await roleService.CreateAsync(AdminRoleName);
                }

                var adminUserExists = await userService.ExistsByEmailAsync(AdminUserEmail);
                if (!adminUserExists)
                {
                    await userService.CreateAsync(Guid.NewGuid(), AdminUserIdentityNumber, AdminUserName, AdminUserEmail, AdminUserPassword);
                }

                var userIsAdmin = await userService.IsInRoleAsync(AdminUserEmail, AdminRoleName);
                if (!userIsAdmin)
                {
                    var adminRole = await roleService.GetByNameAsync(AdminRoleName);
                    var adminUser = await userService.GetByEmailAsync(AdminUserEmail);

                    await userService.AddToRoleAsync(adminUser.Id, adminRole.Id);
                }
            })
            .Wait();


            return app;
        }
    }
}
