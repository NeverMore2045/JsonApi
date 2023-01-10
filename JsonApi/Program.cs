using JsonApi.Message;
using JsonApi.Services;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello");
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
    List<Message.Methods> messages = new List<Message.Methods>()
    {
        new Message.Methods("/ping","Checking the work (Pong if all good)","Get",""),
        new Message.Methods("/status","Info about process (Server Status - OK,Time,Dns)","Get",""),
        new Message.Methods("/calc","Calculator(Quadratic equations)","Post","Double a, Double b, Double c")
    };
    await context.Response.WriteAsJsonAsync<List<Message.Methods>>(messages);
});

app.MapPost("/calc", async (context) =>
{
    CalcMessage.CalcInput input = await context.Request.ReadFromJsonAsync<CalcMessage.CalcInput>(); //new CalcMessage.CalcInput(a, b, c);
    await context.Response.WriteAsJsonAsync(CalcService.SolutionEquation(input));
});

app.Run();
