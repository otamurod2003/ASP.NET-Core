using Microsoft.EntityFrameworkCore;
using StaffManagement.Data;
using StaffManagement.Models;
var builder = WebApplication.CreateBuilder(args);
// Added MVC
builder.Services.AddMvc(options => options.EnableEndpointRouting=false);
//Added new Mapping
builder.Services.AddScoped< IStaffRepository, SqlserverStaffRepository>();
string? my_connection=builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("StaffDb"));
//builder.Services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(my_connection)); 

var app = builder.Build();

app.UseStaticFiles();
app.UseMvcWithDefaultRoute();


app.MapGet("/", () => "Hello World!");

app.Run();
