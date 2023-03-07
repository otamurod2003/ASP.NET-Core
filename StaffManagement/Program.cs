var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc(options => options.EnableEndpointRouting=false);

var app = builder.Build();

app.UseStaticFiles();
app.UseMvcWithDefaultRoute();

app.MapGet("/", () => "Hello World!");

app.Run();
