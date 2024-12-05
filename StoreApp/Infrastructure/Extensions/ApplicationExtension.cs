using System.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace StoreApp.Infrastructe.Extensions
{
    public static class ApplicationExtension
    {
        public static void ConfigureAndCheckMigration(this IApplicationBuilder app) // Migrationları otomatik güncellememiz sağlar.
        {
            RepositoryContext context  = app
            .ApplicationServices
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<RepositoryContext>();

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();  // Dotnet ef database update
            }
        }
    
        public static void ConfigureLocalization(this WebApplication app)
        {
            app.UseRequestLocalization(options => 
                {
                    options.AddSupportedCultures("tr-TR") //Desteklenen Kültür.
                    .AddSupportedUICultures("tr-TR")//UI Kültür.
                    .SetDefaultCulture("tr-TR");//Default Kültür.
                }
            );
        }

        public static void ConfigureRouting(this IServiceCollection services )
        {
            services.AddRouting(options => 
            {
                options.LowercaseUrls=true;
                options.AppendTrailingSlash=true;
            });

        }
        
        public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
        {
            const string adminUser = "Admin";
            const string adminPassword = "Admin+123456";

            // User Manager
            UserManager<IdentityUser> userManager = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();
            //Role Manager
            RoleManager<IdentityRole> roleManager = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            IdentityUser user = await userManager.FindByNameAsync(adminUser);
            if(user is null)
            {
                user = new IdentityUser(adminUser)
                {
                    Email = "zcomert@samsun.edu.tr",
                    PhoneNumber = "5061112333",
                    UserName = adminUser
                };             
                var result = await userManager.CreateAsync(user,adminPassword);
                if(!result.Succeeded)
                    throw new Exception("Admin user could not created.");
                
                var roleResult = await userManager.AddToRolesAsync(user,
                    roleManager
                        .Roles
                        .Select(r => r.Name)
                        .ToList()
                );

                if(!roleResult.Succeeded)
                    throw new Exception("System have problems with role defination for admin.");
            }
        }

    }
}