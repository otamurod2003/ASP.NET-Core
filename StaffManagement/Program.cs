using Microsoft.EntityFrameworkCore;
using StaffManagement.DataAccess;
using StaffManagement.Models;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(options => options.EnableEndpointRouting=false);

builder.Services.AddScoped< IStaffRepository, MockStaffRepository>();
//builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("StaffDb"));


var app = builder.Build();

app.UseStaticFiles();
app.UseMvcWithDefaultRoute();


app.MapGet("/", () => "Hello World!");

app.Run();
