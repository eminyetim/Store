using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;
using StoreApp.Models;

namespace StoreApp.Infrastructe.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration) // This genişletilecek olan sınıf
        {
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("sqlconnection"),
                    b => b.MigrationsAssembly("StoreApp"));
                
                options.EnableSensitiveDataLogging(true);//Login bilgilerini loglarda gçsteriri.
            });
        }

        public static void ConfigureIdentitiy(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<RepositoryContext>();
        }
        
        public static void ConfigureSession(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = "StoreApp.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(10); // Geçen zaman 10dk olunca temizleme yapar.
            }
            );  // Bu iki Servise session yönetimi için lazım.
            services.AddSingleton<HttpContextAccessor, HttpContextAccessor>(); // Bir kere oluşturulması herkesi kullanması yeterli //Request context session yönetimi.Sessionu okumamızı sağlar.
            services.AddScoped<Cart>(c => SessionCart.GetCart(c));
        }

        public static void ConfigureRepositoryRegistration(this IServiceCollection services)
        {
            //IoC
            services.AddScoped<IRepositoryManager, RepositoryManager>();//Repository ile karşılaşırsa RepositoryManager nesnesini çözücek
            services.AddScoped<IProductRepository, ProductRepository>();//Product ile karşılaşırsa ProductRepository nesnesini çözücek
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }

        public static void ConfigureServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>(); //Scoped her kullanıcı için ayrı oluşturur.
            services.AddScoped<IOrderService, OrderManager>(); //Scoped her kullanıcı için ayrı oluşturur.
            services.AddScoped<IAuthService,AuthManager>();
        
        }
    }
}