using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;
using StoreApp.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"),
    b=>b.MigrationsAssembly("StoreApp"));
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "StoreApp.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(10); // Geçen zaman 10dk olunca temizleme yapar.
} 
);  // Bu iki Servise session yönetimi için lazım.
builder.Services.AddSingleton<HttpContextAccessor,HttpContextAccessor>(); // Bir kere oluşturulması herkesi kullanması yeterli //Request context session yönetimi.

builder.Services.AddScoped<IRepositoryManager,RepositoryManager>();//Repository ile karşılaşırsa RepositoryManager nesnesini çözücek
builder.Services.AddScoped<IProductRepository,ProductRepository>();//Product ile karşılaşırsa ProductRepository nesnesini çözücek
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<IOrderRepository,OrderRepository>();


builder.Services.AddScoped<IServiceManager,ServiceManager>();
builder.Services.AddScoped<IProductService,ProductManager>();
builder.Services.AddScoped<ICategoryService,CategoryManager>(); //Scoped her kullanıcı için ayrı oluşturur.
builder.Services.AddScoped<IOrderService,OrderManager>(); //Scoped her kullanıcı için ayrı oluşturur.

builder.Services.AddHttpContextAccessor();//Eklemeyi unuttuğum için çalışmıyor.
builder.Services.AddScoped<Cart>(c => SessionCart.GetCart(c));

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();
app.UseHttpsRedirection();
app.UseRouting();


app.UseEndpoints(endpoints => 
{

    endpoints.MapAreaControllerRoute(
        name : "Admin",
        areaName :"Admin",
        pattern:"Admin/{controller=Dashboard}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
    name :"default", 
    pattern:"{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapRazorPages();
}); 


app.Run();
//istemci taraflı kütüphane yönetimleri Libman ile yapılır json(cdnjs) dosyası eklenir.