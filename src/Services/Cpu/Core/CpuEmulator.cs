using Cpu.Models;

namespace Cpu.Core;

public class CpuEmulator
{
    private readonly InstructionSet _instructionSet;
    private readonly CpuState _state;

    public CpuEmulator()
    {
        _instructionSet = new InstructionSet();
        _state = new CpuState();
    }

    public void ExecuteNextInstruction()
    {
        // Fetch instruction
        // Need memory service... 
        byte opcode = 0xA9;

        // Decode
        var instruction = _instructionSet.GetInstruction(opcode);

        if (instruction != null)
        {
            var address = CalculateAddress(instruction.AddressingMode, _state);

            instruction.Execute(_state, address);

            _state.ProgramCounter += (ushort)instruction.Length;

            _state.Cycles += (ulong)instruction.Cycles;
        }
        else
        {
            // NO-OP
        }
    }

    private ushort CalculateAddress(AddressingMode addressingMode, CpuState state)
    {
        // Need memory...
        throw new NotImplementedException();
    }
}
