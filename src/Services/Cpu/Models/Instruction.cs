namespace Cpu.Models;

public record Instruction(
    string Name,
    AddressingMode AddressingMode,
    int Length,
    int Cycles,
    Action<CpuState, ushort> Execute
);
