using StaffManagement.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
//builder.Services.AddTransient();
//builder.Services.AddScoped();
builder.Services.AddSingleton<IStaffRepository, MockStaffRepository>();
var app = builder.Build();

//app.UseStaticFiles();
//app.UseMvcWithDefaultRoute();
/*app.UseMvc(builder =>
{
    builder.MapRoute("default", "{controller=home}/{action=index}/{id?}");
});*/
app.UseMvc();
app.Run();
