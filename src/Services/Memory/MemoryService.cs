using Grpc.Core;
using GrpcMemory;

namespace Memory;

public class MemoryService : GrpcMemory.Memory.MemoryBase
{
    private readonly byte[] _memory = new byte[65536]; // 64KB

    public MemoryService()
    {
        LoadProgram();
    }

    private void LoadProgram()
    {
        _memory[0x00] = 0xA9;
    }

    public override Task<MemoryResponse> ReadMemory(MemoryRequest request, ServerCallContext context)
    {
        if (request.Address <= 0xFFFF)
        {
            var value = _memory[request.Address];
            return Task.FromResult(new MemoryResponse
            {
                Value = (uint)value,
                Success = true
            });
        }
        else
        {
            return Task.FromResult(new MemoryResponse { Success = false });
        }
    }

    public override Task<MemoryResponse> WriteMemory(MemoryRequest request, ServerCallContext context)
    {
        if (request.Address <= 0xFFFF && request.Value <= 0xFF)
        {
            _memory[request.Address] = (byte)request.Value;
            return Task.FromResult(new MemoryResponse { Success = true });
        }
        else
        {
            return Task.FromResult(new MemoryResponse { Success = false });
        }
    }
}
