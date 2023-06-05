using Microsoft.EntityFrameworkCore;
using R52_Ex_08_Evidence.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DeviceDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();
