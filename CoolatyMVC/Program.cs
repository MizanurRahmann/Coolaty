using CoolatyMVC.Data;
using CoolatyMVC.Data.Repository;
using CoolatyMVC.Services.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using CoolatyMVC.Services.EmailSender;

var builder = WebApplication.CreateBuilder(args);


// ADD SERVICES TO DI CONTAINER
// 1. cotroller with views
builder.Services.AddControllersWithViews();
// 2. application db context
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();
// 3. session
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSession(options => { options.IdleTimeout = TimeSpan.FromSeconds(120); });

// 4. register repositories
builder.Services.AddScoped<Repository, Repository>();

// 5. register services
builder.Services.AddRazorPages();
builder.Services.AddScoped<IEmailSender, FakeEmailSender>();
builder.Services.AddScoped<IService, Service>();


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
app.UseAuthentication();;
app.UseAuthorization();

// ROUTE MAPPING
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

// RUN THE APP
app.Run();
