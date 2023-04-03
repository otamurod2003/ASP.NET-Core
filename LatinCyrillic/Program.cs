var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc( options => options.EnableEndpointRouting = false);
var app = builder.Build();

//added wwwroot
app.UseStaticFiles();

//default routing: Controller= Home, Action = Index, Id ? nullable
app.UseMvcWithDefaultRoute();
app.MapGet("/", () => "Hello World!");

app.Run();
