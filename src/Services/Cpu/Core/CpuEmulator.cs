using Cpu.Models;
using GrpcMemory;

namespace Cpu.Core;

public class CpuEmulator(Memory.MemoryClient memoryClient)
{
    private readonly InstructionSet _instructionSet = new InstructionSet();
    private readonly CpuState _state = new CpuState();
    private readonly Memory.MemoryClient _memoryClient = memoryClient;

    public async Task ExecuteNextInstructionAsync()
    {
        // Fetch instruction
        // Need memory service... 
        //byte opcode = 0xA9;
        var response = await _memoryClient.ReadMemoryAsync(new MemoryRequest { Address = (UInt32)_state.ProgramCounter});
        byte opcode = (byte)response.Value;

        // Decode
        var instruction = _instructionSet.GetInstruction(opcode);

        if (instruction != null)
        {
            var address = await CalculateAddress(instruction.AddressingMode, _state);

            instruction.Execute(_state, address);

            _state.ProgramCounter += (ushort)instruction.Length;

            _state.Cycles += (ulong)instruction.Cycles;
        }
        else
        {
            // NO-OP
        }
    }

    private async Task<ushort> CalculateAddress(AddressingMode addressingMode, CpuState state)
    {
        switch (addressingMode)
        {
            case AddressingMode.Immediate:
                var memoryResponse = await _memoryClient.ReadMemoryAsync(new MemoryRequest { Address = (UInt32)state.ProgramCounter + 1 });
                return (ushort)memoryResponse.Value;

            default:
                throw new NotImplementedException($"Addressing mode {addressingMode} not implemented");
        }
    }
}
