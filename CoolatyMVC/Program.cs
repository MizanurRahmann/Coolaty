using CoolatyMVC.Data;
using CoolatyMVC.Data.Repository.Products;
using CoolatyMVC.Services.Products;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// ADD SERVICES TO DI CONTAINER
// 1. cotroller with views
builder.Services.AddControllersWithViews();
// 2. application db context
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
));
// 3. session
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSession(options => { options.IdleTimeout = TimeSpan.FromSeconds(120); });

// 4. repositories for different actions
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// 5. custom services for different actions
builder.Services.AddScoped<IProductService, ProductService>();

// BUILD THE APP WITH DI CONTAINER
var app = builder.Build();


// ADD MIDDLEWARES WITH THE APP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseStatusCodePagesWithRedirects("/Error/{0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// ROUTE MAPPING
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// RUN THE APP
app.Run();
