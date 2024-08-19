namespace Cpu.Models;

[Flags]
public enum StatusFlags : byte
{
    Carry = 1 << 0,             // 0000 0001
    Zero = 1 << 1,              // 0000 0010
    InterruptDisable = 1 << 2,  // 0000 0100
    DecimalMode = 1 << 3,       // 0000 1000
    BreakCommand = 1 << 4,      // 0001 0000
    Unused = 1 << 5,            // 0010 0000 (usually set to 1)
    Overflow = 1 << 6,          // 0100 0000
    Negative = 1 << 7           // 1000 0000
}

public class CpuState
{
    public byte A { get; set; } // Accumulator
    public byte X { get; set; } // X Register
    public byte Y { get; set; } // Y Register
    public ushort ProgramCounter { get; set; }
    public byte StackPointer { get; set; }

    public StatusFlags Flags
    {
        get => _flags;
    }
    private StatusFlags _flags;

    public bool CarryFlag
    {
        get => (_flags & StatusFlags.Carry) != 0;
        private set => _flags = value ? _flags | StatusFlags.Carry : _flags & ~StatusFlags.Carry;
    }

    public bool ZeroFlag
    {
        get => (_flags & StatusFlags.Zero) != 0;
        private set => _flags = value ? _flags | StatusFlags.Zero : _flags & ~StatusFlags.Zero;
    }
}


