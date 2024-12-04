using System.Net;
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
    
    }
}