using Cpu.Models;

namespace Cpu.Core;

public class InstructionSet
{
    private readonly Dictionary<byte, Instruction> _instructions;

    public InstructionSet()
    {
        _instructions = new Dictionary<byte, Instruction>();
        InitializeInstructions();
    }

    private void InitializeInstructions()
    {
        // Load Accumulator (LDA) instructions
        _instructions[0xA9] = new Instruction("LDA", AddressingMode.Immediate, 2, 2, LdaImmediate);
        _instructions[0xA5] = new Instruction("LDA", AddressingMode.ZeroPage, 2, 3, LdaZeroPage);
        _instructions[0xB5] = new Instruction("LDA", AddressingMode.ZeroPageX, 2, 4, LdaZeroPageX);
        _instructions[0xAD] = new Instruction("LDA", AddressingMode.Absolute, 3, 4, LdaAbsolute);
        _instructions[0xBD] = new Instruction("LDA", AddressingMode.AbsoluteX, 3, 4, LdaAbsoluteX);
        _instructions[0xB9] = new Instruction("LDA", AddressingMode.AbsoluteY, 3, 4, LdaAbsoluteY);
        _instructions[0xA1] = new Instruction("LDA", AddressingMode.IndexedIndirect, 2, 6, LdaIndexedIndirect);
        _instructions[0xB1] = new Instruction("LDA", AddressingMode.IndirectIndexed, 2, 5, LdaIndirectIndexed);

        // ....
    }

    private void LdaIndirectIndexed(CpuState state, ushort address)
    {
        throw new NotImplementedException();
    }

    private void LdaIndexedIndirect(CpuState state, ushort address)
    {
        throw new NotImplementedException();
    }

    private void LdaAbsoluteY(CpuState state, ushort address)
    {
        throw new NotImplementedException();
    }

    private void LdaAbsoluteX(CpuState state, ushort address)
    {
        throw new NotImplementedException();
    }

    private void LdaAbsolute(CpuState state, ushort address)
    {
        throw new NotImplementedException();
    }

    private void LdaZeroPageX(CpuState state, ushort address)
    {
        throw new NotImplementedException();
    }

    private void LdaImmediate(CpuState state, ushort address)
    {
        throw new NotImplementedException();
    }

    private void LdaZeroPage(CpuState state, ushort address)
    {
        throw new NotImplementedException();
    }

    internal Instruction GetInstruction(byte opcode)
    {
        return _instructions[opcode];
    }
}
