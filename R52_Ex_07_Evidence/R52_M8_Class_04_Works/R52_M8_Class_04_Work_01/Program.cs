using Microsoft.EntityFrameworkCore;
using R52_M8_Class_04_Work_01.Models;
using R52_M8_Class_04_Work_01.Repositories;
using R52_M8_Class_04_Work_01.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BrandDbContext>(o=> o.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
