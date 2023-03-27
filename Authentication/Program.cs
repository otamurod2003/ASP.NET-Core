var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
builder.Services.AddMvc(o => o.EnableEndpointRouting = false);
app.UseStaticFiles();
app.UseMvcWithDefaultRoute();
app.UseAuthentication();
app.UseAuthorization();
app.MapGet("/", () => "Hello World!");
app.Run();
