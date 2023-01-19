using JsonApi.Message;
using JsonApi.Services;
using JsonApi.Entity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<JsonApiDbContext>();
builder.Services.AddTransient<CRUDService>();

var app = builder.Build();



app.Use(async (HttpContext context,Func<Task> next) =>
{
    string useragent = context.Request.Headers.UserAgent.ToString();
    KnownHost knownHost = new KnownHost(useragent);
    Request request = new Request(DateTime.Now.ToString() ,context.Request.Path.ToString());
    CRUDService service = context.RequestServices.GetService<CRUDService>();
    service.AddKnownHost(knownHost);
    service.AddRequest(request);
    await next.Invoke();
    // действия после обработки запроса следующим middleware
});

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
    CalcMessage.CalcInput input = await context.Request.ReadFromJsonAsync<CalcMessage.CalcInput>(); 
    await context.Response.WriteAsJsonAsync(CalcService.SolutionEquation(input));
});

app.MapGet("/known-host", async (HttpContext context, CRUDService crudservice) =>
{
    await context.Response.WriteAsJsonAsync(crudservice.GetAllHosts());
});

app.MapGet("/known-requests", async (HttpContext context, CRUDService crudservice) =>
{
    await context.Response.WriteAsJsonAsync(crudservice.GetAllRequests());
});
app.Run();
