namespace Cpu.Models;

public enum AddressingMode
{
    Implied,
    Immediate,
    ZeroPage,
    ZeroPageX,
    ZeroPageY,
    Absolute,
    AbsoluteX,
    AbsoluteY,
    Indirect,
    IndexedIndirect,  // Indirect, X
    IndirectIndexed,  // Indirect, Y
    Relative
}
