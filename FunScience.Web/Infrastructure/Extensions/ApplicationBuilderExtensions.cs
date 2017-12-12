namespace FunScience.Web.Infrastructure.Extensions
{
    using FunScience.Data;
    using FunScience.Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope
                    .ServiceProvider
                    .GetService<FunScienceDbContext>()
                    .Database
                    .Migrate();

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task.Run(async () =>
                {
                    var adminName = GlobalConstants.AdministratorRole;

                    var roleExists =  await roleManager.RoleExistsAsync(adminName);

                    if(!roleExists)
                    {
                        await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = adminName
                        });
                    }

                    var adminEmail = "funsciencetheater@gmail.com";

                    var adminUser = await userManager.FindByEmailAsync(adminEmail);

                    if (adminUser == null)
                    {
                        adminUser = new User
                        {
                            Email = adminEmail,
                            UserName = adminEmail,
                            FirstName = "Maria",
                            LastName = "Nikolova"
                        };

                        await userManager.CreateAsync(adminUser, "Maria1234");

                        await userManager.AddToRoleAsync(adminUser, adminName);
                    }

                })
                .GetAwaiter()
                .GetResult();
            }

            return app;
        }
    }
}
