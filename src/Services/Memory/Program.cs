using Memory;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<MemoryService>();

app.MapGet("/", () => "Memory gRPC service is running!");

app.Run();
