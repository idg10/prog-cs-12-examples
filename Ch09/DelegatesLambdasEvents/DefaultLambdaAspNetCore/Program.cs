WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

app.MapGet("/", (string name = "World") => $"Hello {name}!");

app.Run();