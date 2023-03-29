using Authentication.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc(o=> o.EnableEndpointRouting=false);
builder.Services.AddDbContext<UserDbContext>(q=> q.UseInMemoryDatabase("UserDb"));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<UserDbContext>();
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseMvcWithDefaultRoute();
app.UseAuthentication();
app.UseAuthorization();
app.Run();