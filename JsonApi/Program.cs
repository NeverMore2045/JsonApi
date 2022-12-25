var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/ping", async (context) =>
{
    await context.Response.WriteAsync("Pong");
});
app.MapGet("/status", async (context) =>
{
    await context.Response.WriteAsync(Convert.ToString(System.Diagnostics.Process.GetCurrentProcess()));
});
app.MapGet("/info", async (context) =>
{

});

app.Run();
