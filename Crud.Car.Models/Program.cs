using Crud.Car.Models;
using Crud.Car.Models.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc(o => o.EnableEndpointRouting = false);

var connection = builder.Configuration.GetConnectionString("MyConnection");
builder.Services.AddDbContext<CarDbContext>(o => o.UseSqlServer(connection));
builder.Services.AddScoped<ICarRepository, CarRepository>();
var app = builder.Build();
app.UseStaticFiles();
app.UseMvcWithDefaultRoute();
app.MapGet("/", () => "Hello World!");

app.Run();
