using Microsoft.EntityFrameworkCore;
using restaurant_web_app.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connstr = builder.Configuration.GetConnectionString("DBconn");
builder.Services.AddDbContext<DB>(options => options.UseSqlServer(connstr));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "menu",
        pattern: "Menujat/{action=Index}/{id?}",
        defaults: new { controller = "Menus" });

    endpoints.MapControllerRoute(
        name: "services",
        pattern: "Services/{action=Index}/{id?}",
        defaults: new { controller = "Services" });

    // Additional routes can be defined here
});



app.Run();
