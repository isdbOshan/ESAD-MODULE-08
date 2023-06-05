using Microsoft.EntityFrameworkCore;
using WebApplications.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CarInformationDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("db")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
