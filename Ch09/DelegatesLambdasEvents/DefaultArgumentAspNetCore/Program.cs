WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

static string HandleRootUrl(string name = "World")
{
    return $"Hello {name}!";
}
app.MapGet("/", HandleRootUrl);

app.Run();