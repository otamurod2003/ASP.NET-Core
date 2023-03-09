using StaffManagement.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(options => options.EnableEndpointRouting=false);

builder.Services.AddSingleton< IStaffRepository, MockStaffRepository>();


var app = builder.Build();

app.UseStaticFiles();
app.UseMvcWithDefaultRoute();


app.MapGet("/", () => "Hello World!");

app.Run();
