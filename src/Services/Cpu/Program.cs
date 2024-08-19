using Cpu.Core;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpcClient<GrpcMemory.Memory.MemoryClient>(options =>
{
    options.Address = new Uri("https://localhost:5051");
});
builder.Services.AddSingleton<CpuEmulator>();

var app = builder.Build();

app.MapGet("/", async () => 
{ 
    CpuEmulator cpuEmulator = app.Services.GetRequiredService<CpuEmulator>();
    await cpuEmulator.ExecuteNextInstructionAsync();
});

app.Run();
