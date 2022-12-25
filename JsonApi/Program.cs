using JsonApi.Message;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/ping", async (context) =>
{
    await context.Response.WriteAsync("Pong");
});
app.MapGet("/status", async (context) =>
{
    Message.ServerStatus serverStatus = new Message.ServerStatus("OK", DateTime.Now, System.Net.Dns.GetHostName());
    await context.Response.WriteAsJsonAsync(serverStatus);
});
app.MapGet("/info", async (context) =>
{
    await context.Response.WriteAsync("Methods: /ping(checking the work), /status(info about process)");
});

app.Run();
