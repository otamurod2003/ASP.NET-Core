using StaffManagement.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
//builder.Services.AddTransient();
builder.Services.AddSingleton<IStaffRepository, MockStaffRepository>();
var app = builder.Build();

app.UseStaticFiles();
app.UseMvcWithDefaultRoute();
app.MapGet("/", () =>"");

app.Run();
